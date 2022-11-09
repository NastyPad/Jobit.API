using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface ITechSkillRepository
{
    Task<IEnumerable<TechSkill>> ListTechSkillAsync();
    Task<TechSkill> FindTechSkillByTechSkillIdAsync(long techSkillId);
    Task AddTechSkillAsync(TechSkill newTechSkill);
    void UpdateTechSkill(TechSkill updatedTechSkill);
    void DeleteTechSkill(TechSkill toDeleteTechSkill);
    
}