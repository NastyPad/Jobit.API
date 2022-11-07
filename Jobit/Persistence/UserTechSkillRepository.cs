using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class UserTechSkillRepository: BaseRepository, IUserTechSkillRepository
{
    public UserTechSkillRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<UserTechSkill> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId)
    {
        return await _databaseContext.UserTechSkills.FindAsync(userId, techSkillId);
    }

    public async Task<IEnumerable<UserTechSkill>> ListUserTechSkillByUserIdAsync(long userId)
    {
        return await _databaseContext.UserTechSkills.Where(u => u.UserId == userId).ToListAsync();
    }

    public Task<IEnumerable<UserTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId)
    {
        throw new NotImplementedException();
    }

    public Task AddUserTechSkill(UserTechSkill newUserTechSkill)
    {
        throw new NotImplementedException();
    }

    public void UpdateUserTechSkill(UserTechSkill updatedUserTechSkill)
    {
        throw new NotImplementedException();
    }

    public void DeleteUserTechSkill(UserTechSkill toDeleteUserTechSkill)
    {
        throw new NotImplementedException();
    }
}