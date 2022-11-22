using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IApplicantProfileTechSkillService
{
    Task<UserProfileTechSkillResponse> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId);
    Task<IEnumerable<ApplicantProfileTechSkill>> ListUserTechSkillByUserIdAdAsync(long userId);
    Task<IEnumerable<ApplicantProfileTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId);
    Task<UserProfileTechSkillResponse> AddUserProfileTechSkillAsync(ApplicantProfileTechSkill newApplicantProfileTechSkill);
    Task<UserProfileTechSkillResponse> UpdateUserTechSkillAsync(long userId, long techSkillId, ApplicantProfileTechSkill updatedApplicantProfileTechSkill);
    Task<UserProfileTechSkillResponse> DeleteUserTechSkillAsync(long userId, long techSkillId);
}