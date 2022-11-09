using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileTechSkillRepository _userProfileTechSkillRepository;
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly ITechSkillRepository _techSkillRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserProfileService(IUserProfileRepository userProfileRepository, ITechSkillRepository techSkillRepository,
        IUserRepository userRepository, IUserProfileTechSkillRepository userProfileTechSkillRepository,
        IUnitOfWork unitOfWork)
    {
        _techSkillRepository = techSkillRepository;
        _userRepository = userRepository;
        _userProfileRepository = userProfileRepository;
        _unitOfWork = unitOfWork;
        _userProfileTechSkillRepository = userProfileTechSkillRepository;
    }


    public async Task<IEnumerable<UserProfile>> ListUserProfilesAsync()
    {
        var userProfiles = await _userProfileRepository.ListUserProfilesAsync();
        userProfiles.ToList().ForEach(
            (userProfile) =>
            {
                SetUserProfileObjects(userProfile);
            }
        );

        return userProfiles.AsEnumerable();
    }

    public async Task<UserProfileResponse> FindUserProfileByUserIdAsync(long userId)
    {
        var existingUserProfile = await _userProfileRepository.FindUserProfileByUserIdAsync(userId);
        if (existingUserProfile == null)
            return new UserProfileResponse("Not found");
        try
        {
            await SetUserProfileObjects(existingUserProfile);
            
            return new UserProfileResponse(existingUserProfile);
        }
        catch (Exception exception)
        {
            return new UserProfileResponse($"An error has ocurred:{exception.Message}");
        }
    }

    public Task SetUserProfileObjects(UserProfile toSetUserProfile)
    {
        toSetUserProfile.UserProfileTechSkills = _userProfileTechSkillRepository
            .ListUserProfileTechSkillByUserIdAsync(toSetUserProfile.UserId).Result.ToList();
        toSetUserProfile.UserProfileTechSkills.ToList().ForEach(
            (userProfileTechSkill) =>
            {
                userProfileTechSkill.TechSkill = _techSkillRepository
                    .FindTechSkillByTechSkillIdAsync(userProfileTechSkill.TechSkillId).Result;
            }
        );
        return Task.CompletedTask;
    }

    public async Task<UserProfileResponse> AddUserProfileAsync(UserProfile newUserProfile)
    {
        try
        {
            await _userProfileRepository.AddUserProfileAsync(newUserProfile);
            await _unitOfWork.CompleteAsync();
            return new UserProfileResponse(newUserProfile);
        }
        catch (Exception exception)
        {
            return new UserProfileResponse($"An error has ocurred:{exception.Message}");
        }
    }

    public async Task<UserProfileResponse> UpdatedUserProfileAsync(long userId, UserProfile updateUserProfile)
    {
        throw new NotImplementedException();
    }

    public async Task<UserProfileResponse> DeleteUserProfileAsync(long userId)
    {
        throw new NotImplementedException();
    }
}