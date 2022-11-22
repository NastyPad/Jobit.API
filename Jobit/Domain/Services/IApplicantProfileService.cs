using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IApplicantProfileService
{
    Task<IEnumerable<ApplicantProfile>> ListUserProfilesAsync();
    Task<UserProfileResponse> FindUserProfileByUserIdAsync(long userId);
    Task SetUserProfileObjects(ApplicantProfile toSetApplicantProfile);
    Task<UserProfileResponse> AddUserProfileAsync(ApplicantProfile newApplicantProfile);
    Task<UserProfileResponse> UpdatedUserProfileAsync(long userId, ApplicantProfile updateApplicantProfile);
    Task<UserProfileResponse> DeleteUserProfileAsync(long userId);

}