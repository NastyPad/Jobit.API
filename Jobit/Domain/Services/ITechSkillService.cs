using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface ITechSkillService
{
    Task<IEnumerable<TechSkill>> LisTechSkillsAsync();
    Task<TechSkillResponse> FindTechSkillByTechSkillIdAsync(long techSkillId);
    Task<TechSkillResponse> AddTechSkillAsync(TechSkill newTechSkill);
    Task<TechSkillResponse> UpdateTechSkillAsync(long techSkillId, TechSkill updatedTechSkill);
    Task<TechSkillResponse> DeleteTechSkillAsync(long techSkillId);
}