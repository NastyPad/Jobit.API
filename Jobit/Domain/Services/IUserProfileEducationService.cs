using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IUserProfileEducationService
{
    Task<IEnumerable<UserProfileEducation>> ListUserProfileEducationsByUserIdAsync(long userId);
    Task<UserProfileEducationResponse> FindUserProfileEducationByUserProfileEducationId(long userProfileEducationId);
    Task<UserProfileEducationResponse> AddUserProfileEducationAsync(UserProfileEducation newUserProfileEducation);
    Task<UserProfileEducationResponse> UpdateUserProfileEducationAsync(long userProfileEducationId, UserProfileEducation updatedUserProfileEducation);
    Task<UserProfileEducationResponse> DeleteUserProfileEducationAsync(long userProfileEducationId);
    Task SetUserProfileEducationObjects(UserProfileEducation toSetUserProfileEducation);

}