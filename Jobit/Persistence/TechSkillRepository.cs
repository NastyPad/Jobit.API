using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class TechSkillRepository: BaseRepository, ITechSkillRepository
{
    public TechSkillRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<TechSkill>> ListTechSkillAsync()
    { 
        return await _databaseContext.TechSkills.ToListAsync();
    }

    public async Task<TechSkill> FindTechSkillByTechSkillIdAsync(long techSkillId)
    {
        return await _databaseContext.TechSkills.FindAsync(techSkillId);
    }

    public async Task AddTechSkillAsync(TechSkill newTechSkill)
    {
        await _databaseContext.TechSkills.AddAsync(newTechSkill);
    }

    public void UpdateTechSkill(TechSkill updatedTechSkill)
    { 
        _databaseContext.Update(updatedTechSkill);
    }

    public void DeleteTechSkill(TechSkill toDeleteTechSkill)
    {
        _databaseContext.Remove(toDeleteTechSkill);
    }
}