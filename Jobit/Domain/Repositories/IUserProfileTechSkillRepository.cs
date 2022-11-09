using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IUserProfileTechSkillRepository
{
    Task<UserProfileTechSkill> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId);
    Task<IEnumerable<UserProfileTechSkill>> ListUserProfileTechSkillByUserIdAsync(long userId);
    Task<IEnumerable<UserProfileTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId);

    Task AddUserTechSkill(UserProfileTechSkill newUserProfileTechSkill);
    void UpdateUserTechSkill(UserProfileTechSkill updatedUserProfileTechSkill);
    void DeleteUserTechSkill(UserProfileTechSkill toDeleteUserProfileTechSkill);

}