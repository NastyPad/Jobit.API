using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class ApplicantProfileService : IApplicantProfileService
{
    private readonly IApplicantProfileTechSkillRepository _applicantProfileTechSkillRepository;
    private readonly IApplicantProfileRepository _applicantProfileRepository;
    private readonly ITechSkillRepository _techSkillRepository;
    private readonly IEducationRepository _educationRepository;
    private readonly IApplicantProfileEducationRepository _applicantProfileEducationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicantProfileService(IEducationRepository educationRepository,IApplicantProfileRepository applicantProfileRepository, ITechSkillRepository techSkillRepository,
        IApplicantProfileEducationRepository applicantProfileEducationRepository, IApplicantProfileTechSkillRepository applicantProfileTechSkillRepository,
        IUnitOfWork unitOfWork)
    {
        _educationRepository = educationRepository;
        _techSkillRepository = techSkillRepository;
        _applicantProfileEducationRepository = applicantProfileEducationRepository;
        _applicantProfileRepository = applicantProfileRepository;
        _unitOfWork = unitOfWork;
        _applicantProfileTechSkillRepository = applicantProfileTechSkillRepository;
    }


    public async Task<IEnumerable<ApplicantProfile>> ListUserProfilesAsync()
    {
        var userProfiles = await _applicantProfileRepository.ListUserProfilesAsync();
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
        var existingUserProfile = await _applicantProfileRepository.FindUserProfileByUserIdAsync(userId);
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

    public Task SetUserProfileObjects(ApplicantProfile toSetApplicantProfile)
    {
        //Set UserProfileTechSkills
        toSetApplicantProfile.ApplicantProfileTechSkills = _applicantProfileTechSkillRepository
            .ListUserProfileTechSkillByUserIdAsync(toSetApplicantProfile.ApplicantId).Result.ToList();
        toSetApplicantProfile.ApplicantProfileTechSkills.ToList().ForEach(
            (userProfileTechSkill) =>
            {
                userProfileTechSkill.TechSkill = _techSkillRepository
                    .FindTechSkillByTechSkillIdAsync(userProfileTechSkill.TechSkillId).Result;
            }
        );
        //Set UserProfileEducations
        toSetApplicantProfile.ApplicantProfileEducations = _applicantProfileEducationRepository
            .ListUserProfileEducationsByUserIdAsync(toSetApplicantProfile.ApplicantId).Result.ToList();
        toSetApplicantProfile.ApplicantProfileEducations.ToList().ForEach(
            (userProfileEducation) =>
            {
                userProfileEducation.Education = _educationRepository
                    .FindEducationByInstitutionIdAsync(userProfileEducation.EducationId).Result;
            }
        );
        
        return Task.CompletedTask;
    }

    public async Task<UserProfileResponse> AddUserProfileAsync(ApplicantProfile newApplicantProfile)
    {
        try
        {
            await _applicantProfileRepository.AddApplicantProfileAsync(newApplicantProfile);
            await _unitOfWork.CompleteAsync();
            return new UserProfileResponse(newApplicantProfile);
        }
        catch (Exception exception)
        {
            return new UserProfileResponse($"An error has ocurred:{exception.Message}");
        }
    }

    public async Task<UserProfileResponse> UpdatedUserProfileAsync(long userId, ApplicantProfile updateApplicantProfile)
    {
        var existingUserProfile = await _applicantProfileRepository.FindUserProfileByUserIdAsync(userId);
        if (existingUserProfile == null)
            return new UserProfileResponse("User does not exist.");

        existingUserProfile.SetApplicantProfile(updateApplicantProfile);
        
        try
        {
            _applicantProfileRepository.UpdateUserProfile(existingUserProfile);
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