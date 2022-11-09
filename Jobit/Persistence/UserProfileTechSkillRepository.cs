using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class UserProfileTechSkillRepository: BaseRepository, IUserProfileTechSkillRepository
{
    public UserProfileTechSkillRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<UserProfileTechSkill> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId)
    {
        return await _databaseContext.UserTechSkills.FindAsync(userId, techSkillId);
    }

    public async Task<IEnumerable<UserProfileTechSkill>> ListUserProfileTechSkillByUserIdAsync(long userId)
    {
        return await _databaseContext.UserTechSkills.Where(u => u.UserId == userId).ToListAsync();
    }

    public Task<IEnumerable<UserProfileTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId)
    {
        throw new NotImplementedException();
    }

    public Task AddUserTechSkill(UserProfileTechSkill newUserProfileTechSkill)
    {
        throw new NotImplementedException();
    }

    public void UpdateUserTechSkill(UserProfileTechSkill updatedUserProfileTechSkill)
    {
        throw new NotImplementedException();
    }

    public void DeleteUserTechSkill(UserProfileTechSkill toDeleteUserProfileTechSkill)
    {
        throw new NotImplementedException();
    }
}