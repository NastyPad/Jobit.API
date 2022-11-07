using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IUserTechSkillService
{
    Task<UserTechSkillResponse> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId);
    Task<UserTechSkillResponse> ListUserTechSkillByUserIdAdAsync(long userId);
    Task<UserTechSkillResponse> ListUserTechSkillByTechSkillIdAsync(long techSkillId);
    Task<UserTechSkillResponse> AddUserTechSkillAsync(UserTechSkill newUserTechSkill);
    Task<UserTechSkillResponse> UpdateUserTechSkillAsync(long userId, UserTechSkill updatedUserTechSkill);
    Task<UserTechSkillResponse> DeleteUserTechSkillAsync(long userId, long techSkillId);
}