using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jobit.API.Jobit.Services;

public class UserProfileSkillTechService: IUserProfileTechSkillService
{
    private readonly IUserProfileTechSkillRepository _userProfileTechSkillRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserProfileSkillTechService(IUserProfileTechSkillRepository userProfileTechSkillRepository, IUnitOfWork unitOfWork)
    {
        _userProfileTechSkillRepository = userProfileTechSkillRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<UserProfileTechSkillResponse> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserProfileTechSkill>> ListUserTechSkillByUserIdAdAsync(long userId)
    {
        return await _userProfileTechSkillRepository.ListUserProfileTechSkillByUserIdAsync(userId);
    }

    public Task<IEnumerable<UserProfileTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId)
    {
        throw new NotImplementedException();
    }

    public Task<UserProfileTechSkillResponse> AddUserTechSkillAsync(UserProfileTechSkill newUserProfileTechSkill)
    {
        throw new NotImplementedException();
    }

    public Task<UserProfileTechSkillResponse> UpdateUserTechSkillAsync(long userId, UserProfileTechSkill updatedUserProfileTechSkill)
    {
        throw new NotImplementedException();
    }

    public Task<UserProfileTechSkillResponse> DeleteUserTechSkillAsync(long userId, long techSkillId)
    {
        throw new NotImplementedException();
    }
}