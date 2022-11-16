using Jobit.API.Jobit.Domain.Models.Intermediate;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IUserProfileEducationRepository
{
    Task<UserProfileEducation> FindUserProfileEducationByUserProfileEducationId(long userProfileEducationId);
    Task<IEnumerable<UserProfileEducation>> ListUserProfileEducations();
    Task<IEnumerable<UserProfileEducation>> ListUserProfileEducationsByUserIdAsync(long userId);
    Task AddUserProfileEducationAsync(UserProfileEducation newUserProfileEducation);
    void UpdateUserProfileEducation(UserProfileEducation updatedUserProfileEducation);
    void DeleteUserProfileEducation(UserProfileEducation toDeleteUserProfileEducation);
}