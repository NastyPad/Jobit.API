using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IUserProfileTechSkillService
{
    Task<UserProfileTechSkillResponse> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId);
    Task<IEnumerable<UserProfileTechSkill>> ListUserTechSkillByUserIdAdAsync(long userId);
    Task<IEnumerable<UserProfileTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId);
    Task<UserProfileTechSkillResponse> AddUserProfileTechSkillAsync(UserProfileTechSkill newUserProfileTechSkill);
    Task<UserProfileTechSkillResponse> UpdateUserTechSkillAsync(long userId, long techSkillId, UserProfileTechSkill updatedUserProfileTechSkill);
    Task<UserProfileTechSkillResponse> DeleteUserTechSkillAsync(long userId, long techSkillId);
}