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
    private readonly IEducationRepository _educationRepository;
    private readonly IUserProfileEducationRepository _userProfileEducationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserProfileService(IEducationRepository educationRepository,IUserProfileRepository userProfileRepository, ITechSkillRepository techSkillRepository,
        IUserProfileEducationRepository userProfileEducationRepository, IUserProfileTechSkillRepository userProfileTechSkillRepository,
        IUnitOfWork unitOfWork)
    {
        _educationRepository = educationRepository;
        _techSkillRepository = techSkillRepository;
        _userProfileEducationRepository = userProfileEducationRepository;
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
        //Set UserProfileTechSkills
        toSetUserProfile.UserProfileTechSkills = _userProfileTechSkillRepository
            .ListUserProfileTechSkillByUserIdAsync(toSetUserProfile.UserId).Result.ToList();
        toSetUserProfile.UserProfileTechSkills.ToList().ForEach(
            (userProfileTechSkill) =>
            {
                userProfileTechSkill.TechSkill = _techSkillRepository
                    .FindTechSkillByTechSkillIdAsync(userProfileTechSkill.TechSkillId).Result;
            }
        );
        //Set UserProfileEducations
        toSetUserProfile.UserProfileEducations = _userProfileEducationRepository
            .ListUserProfileEducationsByUserIdAsync(toSetUserProfile.UserId).Result.ToList();
        toSetUserProfile.UserProfileEducations.ToList().ForEach(
            (userProfileEducation) =>
            {
                userProfileEducation.Education = _educationRepository
                    .FindEducationByInstitutionIdAsync(userProfileEducation.EducationId).Result;
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
        var existingUserProfile = await _userProfileRepository.FindUserProfileByUserIdAsync(userId);
        if (existingUserProfile == null)
            return new UserProfileResponse("User does not exist.");

        existingUserProfile.SetUserProfile(updateUserProfile);
        
        try
        {
            _userProfileRepository.UpdateUserProfile(existingUserProfile);
            await _unitOfWork.CompleteAsync();
            return new UserProfileResponse(existingUserProfile);
        }
        catch (Exception exception)
        {
            return new UserProfileResponse($"An error has ocurred: {exception.Message}");
        }
    }

    public async Task<UserProfileResponse> DeleteUserProfileAsync(long userId)
    {
        throw new NotImplementedException();
    }
}