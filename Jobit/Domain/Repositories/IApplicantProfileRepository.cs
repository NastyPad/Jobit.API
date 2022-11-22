using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IApplicantProfileRepository
{
    Task<IEnumerable<ApplicantProfile>> ListUserProfilesAsync();
    Task<ApplicantProfile> FindUserProfileByUserIdAsync(long userId);
    Task AddApplicantProfileAsync(ApplicantProfile newApplicantProfile);
    void UpdateUserProfile(ApplicantProfile updatedApplicantProfile);
    void DeleteUserProfile(ApplicantProfile toDeleteApplicantProfile);
}