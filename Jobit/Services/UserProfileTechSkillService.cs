using System.Collections.Immutable;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jobit.API.Jobit.Services;

public class UserProfileTechSkillService: IUserProfileTechSkillService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserProfileTechSkillRepository _userProfileTechSkillRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserProfileTechSkillService(IUserRepository userRepository, IUserProfileTechSkillRepository userProfileTechSkillRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _userProfileTechSkillRepository = userProfileTechSkillRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<UserProfileTechSkillResponse> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserProfileTechSkill>> ListUserTechSkillByUserIdAdAsync(long userId)
    {
        var existingUser = await _userRepository.FindUserByUserIdAsync(userId);
        if (existingUser == null)
            return Enumerable.Empty<UserProfileTechSkill>();
        return await _userProfileTechSkillRepository.ListUserProfileTechSkillByUserIdAsync(userId);
    }

    public Task<IEnumerable<UserProfileTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId)
    {
        throw new NotImplementedException();
    }

    public async Task<UserProfileTechSkillResponse> AddUserProfileTechSkillAsync(UserProfileTechSkill newUserProfileTechSkill)
    {
        var existingUserProfileTechSkill = await _userProfileTechSkillRepository.FindUserTechSkillByUserIdAndTechSkillIdAsync(newUserProfileTechSkill.UserId, newUserProfileTechSkill.TechSkillId);
        if (existingUserProfileTechSkill != null)
            return new UserProfileTechSkillResponse("This userprofile techs-kill also exist. Please modify it.");
        try
        {
            await _userProfileTechSkillRepository.AddUserProfileTechSkill(newUserProfileTechSkill);
            await _unitOfWork.CompleteAsync();
            return new UserProfileTechSkillResponse(newUserProfileTechSkill);
        }
        catch (Exception exception)
        {
            return new UserProfileTechSkillResponse($"An error has occurred: {exception.Message}");
        }
    }
    
    public async Task<UserProfileTechSkillResponse> UpdateUserTechSkillAsync(long userId, long techSkillId, UserProfileTechSkill updatedUserProfileTechSkill)
    {
        var existingUserProfileTechSkill = await _userProfileTechSkillRepository.FindUserTechSkillByUserIdAndTechSkillIdAsync(updatedUserProfileTechSkill.UserId, updatedUserProfileTechSkill.TechSkillId);
        if (existingUserProfileTechSkill == null)
            return new UserProfileTechSkillResponse("This userprofile tech-skill does not exist");
        
        existingUserProfileTechSkill.SetUserProfileTechSkill(updatedUserProfileTechSkill);
        
        try
        {
            _userProfileTechSkillRepository.UpdateUserProfileTechSkill(updatedUserProfileTechSkill);
            await _unitOfWork.CompleteAsync();
            return new UserProfileTechSkillResponse(updatedUserProfileTechSkill);
        }
        catch (Exception exception)
        {
            return new UserProfileTechSkillResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<UserProfileTechSkillResponse> DeleteUserTechSkillAsync(long userId, long techSkillId)
    {
        var existingUserProfileTechSkill = await _userProfileTechSkillRepository.FindUserTechSkillByUserIdAndTechSkillIdAsync(userId, techSkillId);
        if (existingUserProfileTechSkill == null)
            return new UserProfileTechSkillResponse("This userprofile techs-kill does not exist");
        
        try
        {
            _userProfileTechSkillRepository.DeleteUserProfileTechSkill(existingUserProfileTechSkill);
            await _unitOfWork.CompleteAsync();
            return new UserProfileTechSkillResponse(existingUserProfileTechSkill);
        }
        catch (Exception exception)
        {
            return new UserProfileTechSkillResponse($"An error has occurred: {exception.Message}");
        }
    }
}