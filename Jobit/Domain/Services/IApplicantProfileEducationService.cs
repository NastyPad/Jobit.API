using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IApplicantProfileEducationService
{
    Task<IEnumerable<ApplicantProfileEducation>> ListUserProfileEducationsByUserIdAsync(long userId);
    Task<UserProfileEducationResponse> FindUserProfileEducationByUserProfileEducationId(long userProfileEducationId);
    Task<UserProfileEducationResponse> AddUserProfileEducationAsync(ApplicantProfileEducation newApplicantProfileEducation);
    Task<UserProfileEducationResponse> UpdateUserProfileEducationAsync(long userProfileEducationId, ApplicantProfileEducation updatedApplicantProfileEducation);
    Task<UserProfileEducationResponse> DeleteUserProfileEducationAsync(long userProfileEducationId);
    Task SetUserProfileEducationObjects(ApplicantProfileEducation toSetApplicantProfileEducation);

}