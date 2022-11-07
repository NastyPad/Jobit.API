using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class UserProfileService: IUserProfileService
{
    private readonly IUserTechSkillRepository _userTechSkillRepository;
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserProfileService(IUserProfileRepository userProfileRepository, IUserRepository userRepository, IUserTechSkillRepository userTechSkillRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _userProfileRepository = userProfileRepository;
        _unitOfWork = unitOfWork;
        _userTechSkillRepository = userTechSkillRepository;
    }


    public async Task<IEnumerable<UserProfile>> ListUserProfilesAsync()
    {
        var userProfiles = await _userProfileRepository.ListUserProfilesAsync();
        userProfiles.ToList().ForEach(
            (userProfile) =>
            {
                userProfile.UserTechSkills = _userTechSkillRepository.ListUserTechSkillByUserIdAsync(userProfile.UserId).Result.ToList();
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
            return new UserProfileResponse(existingUserProfile);
        }
        catch (Exception exception)
        {
            return new UserProfileResponse($"An error has ocurred:{exception.Message}");
        }
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