using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class ApplicantProfileTechSkillRepository: BaseRepository, IApplicantProfileTechSkillRepository
{
    public ApplicantProfileTechSkillRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<ApplicantProfileTechSkill> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId)
    {
        return await _databaseContext.ApplicantProfileTechSkills.FindAsync(userId, techSkillId);
    }

    public async Task<IEnumerable<ApplicantProfileTechSkill>> ListUserProfileTechSkillByUserIdAsync(long userId)
    {
        return await _databaseContext.ApplicantProfileTechSkills.Where(u => u.ApplicantId == userId).ToListAsync();
    }
    
    public async Task<IEnumerable<ApplicantProfileTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId)
    {
        return await _databaseContext.ApplicantProfileTechSkills.Where(u => u.TechSkillId == techSkillId).ToListAsync();
    }

    public async Task AddUserProfileTechSkill(ApplicantProfileTechSkill newApplicantProfileTechSkill)
    {
        await _databaseContext.ApplicantProfileTechSkills.AddAsync(newApplicantProfileTechSkill);
    }

    public void UpdateUserProfileTechSkill(ApplicantProfileTechSkill updatedApplicantProfileTechSkill)
    {
        _databaseContext.ApplicantProfileTechSkills.Update(updatedApplicantProfileTechSkill);
    }

    public void DeleteUserProfileTechSkill(ApplicantProfileTechSkill toDeleteApplicantProfileTechSkill)
    {
        _databaseContext.ApplicantProfileTechSkills.Remove(toDeleteApplicantProfileTechSkill);
    }
}