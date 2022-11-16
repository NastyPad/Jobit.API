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
        return await _databaseContext.UserProfileTechSkills.FindAsync(userId, techSkillId);
    }

    public async Task<IEnumerable<UserProfileTechSkill>> ListUserProfileTechSkillByUserIdAsync(long userId)
    {
        return await _databaseContext.UserProfileTechSkills.Where(u => u.UserId == userId).ToListAsync();
    }
    
    public async Task<IEnumerable<UserProfileTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId)
    {
        return await _databaseContext.UserProfileTechSkills.Where(u => u.TechSkillId == techSkillId).ToListAsync();
    }

    public async Task AddUserProfileTechSkill(UserProfileTechSkill newUserProfileTechSkill)
    {
        await _databaseContext.UserProfileTechSkills.AddAsync(newUserProfileTechSkill);
    }

    public void UpdateUserProfileTechSkill(UserProfileTechSkill updatedUserProfileTechSkill)
    {
        _databaseContext.UserProfileTechSkills.Update(updatedUserProfileTechSkill);
    }

    public void DeleteUserProfileTechSkill(UserProfileTechSkill toDeleteUserProfileTechSkill)
    {
        _databaseContext.UserProfileTechSkills.Remove(toDeleteUserProfileTechSkill);
    }
}