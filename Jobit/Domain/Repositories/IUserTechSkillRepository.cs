using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IUserTechSkillRepository
{
    Task<UserTechSkill> FindUserTechSkillByUserIdAndTechSkillIdAsync(long userId, long techSkillId);
    Task<IEnumerable<UserTechSkill>> ListUserTechSkillByUserIdAsync(long userId);
    Task<IEnumerable<UserTechSkill>> ListUserTechSkillByTechSkillIdAsync(long techSkillId);

    Task AddUserTechSkill(UserTechSkill newUserTechSkill);
    void UpdateUserTechSkill(UserTechSkill updatedUserTechSkill);
    void DeleteUserTechSkill(UserTechSkill toDeleteUserTechSkill);

}