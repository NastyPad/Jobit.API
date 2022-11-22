using System.Collections.Immutable;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jobit.API.Jobit.Services;

public class ApplicantProfileTechSkillService: IApplicantProfileTechSkillService
{
    private readonly IUserRepository _userRepository;
    private readonly IApplicantProfileTechSkillRepository _applicantProfileTechSkillRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicantProfileTechSkillService(IUserRepository userRepository, IApplicantProfileTechSkillRepository applicantProfileTechSkillRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _applicantProfileTechSkillRepository = applicantProfileTechSkillRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<UserProfileTechSkillResponse> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ApplicantProfileTechSkill>> ListUserTechSkillByUserIdAdAsync(long userId)
    {
        var existingUser = await _userRepository.FindUserByUserIdAsync(userId);
        if (existingUser == null)
            return Enumerable.Empty<ApplicantProfileTechSkill>();
        return await _applicantProfileTechSkillRepository.ListUserProfileTechSkillByUserIdAsync(userId);
    }

    public Task<IEnumerable<ApplicantProfileTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId)
    {
        throw new NotImplementedException();
    }

    public async Task<UserProfileTechSkillResponse> AddUserProfileTechSkillAsync(ApplicantProfileTechSkill newApplicantProfileTechSkill)
    {
        var existingUserProfileTechSkill = await _applicantProfileTechSkillRepository.FindUserTechSkillByUserIdAndTechSkillIdAsync(newApplicantProfileTechSkill.ApplicantId, newApplicantProfileTechSkill.TechSkillId);
        if (existingUserProfileTechSkill != null)
            return new UserProfileTechSkillResponse("This userprofile techs-kill also exist. Please modify it.");
        try
        {
            await _applicantProfileTechSkillRepository.AddUserProfileTechSkill(newApplicantProfileTechSkill);
            await _unitOfWork.CompleteAsync();
            return new UserProfileTechSkillResponse(newApplicantProfileTechSkill);
        }
        catch (Exception exception)
        {
            return new UserProfileTechSkillResponse($"An error has occurred: {exception.Message}");
        }
    }
    
    public async Task<UserProfileTechSkillResponse> UpdateUserTechSkillAsync(long userId, long techSkillId, ApplicantProfileTechSkill updatedApplicantProfileTechSkill)
    {
        var existingUserProfileTechSkill = await _applicantProfileTechSkillRepository.FindUserTechSkillByUserIdAndTechSkillIdAsync(updatedApplicantProfileTechSkill.ApplicantId, updatedApplicantProfileTechSkill.TechSkillId);
        if (existingUserProfileTechSkill == null)
            return new UserProfileTechSkillResponse("This userprofile tech-skill does not exist");
        
        existingUserProfileTechSkill.SetUserProfileTechSkill(updatedApplicantProfileTechSkill);
        
        try
        {
            _applicantProfileTechSkillRepository.UpdateUserProfileTechSkill(updatedApplicantProfileTechSkill);
            await _unitOfWork.CompleteAsync();
            return new UserProfileTechSkillResponse(updatedApplicantProfileTechSkill);
        }
        catch (Exception exception)
        {
            return new UserProfileTechSkillResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<UserProfileTechSkillResponse> DeleteUserTechSkillAsync(long userId, long techSkillId)
    {
        var existingUserProfileTechSkill = await _applicantProfileTechSkillRepository.FindUserTechSkillByUserIdAndTechSkillIdAsync(userId, techSkillId);
        if (existingUserProfileTechSkill == null)
            return new UserProfileTechSkillResponse("This userprofile techs-kill does not exist");
        
        try
        {
            _applicantProfileTechSkillRepository.DeleteUserProfileTechSkill(existingUserProfileTechSkill);
            await _unitOfWork.CompleteAsync();
            return new UserProfileTechSkillResponse(existingUserProfileTechSkill);
        }
        catch (Exception exception)
        {
            return new UserProfileTechSkillResponse($"An error has occurred: {exception.Message}");
        }
    }
}