using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IApplicantProfileTechSkillRepository
{
    Task<ApplicantProfileTechSkill> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId);
    Task<IEnumerable<ApplicantProfileTechSkill>> ListUserProfileTechSkillByUserIdAsync(long userId);
    Task<IEnumerable<ApplicantProfileTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId);
    Task AddUserProfileTechSkill(ApplicantProfileTechSkill newApplicantProfileTechSkill);
    void UpdateUserProfileTechSkill(ApplicantProfileTechSkill updatedApplicantProfileTechSkill);
    void DeleteUserProfileTechSkill(ApplicantProfileTechSkill toDeleteApplicantProfileTechSkill);

}