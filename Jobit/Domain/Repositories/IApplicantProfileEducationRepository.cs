using Jobit.API.Jobit.Domain.Models.Intermediate;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IApplicantProfileEducationRepository
{
    Task<ApplicantProfileEducation> FindUserProfileEducationByUserProfileEducationId(long userProfileEducationId);
    Task<IEnumerable<ApplicantProfileEducation>> ListUserProfileEducations();
    Task<IEnumerable<ApplicantProfileEducation>> ListUserProfileEducationsByUserIdAsync(long userId);
    Task AddUserProfileEducationAsync(ApplicantProfileEducation newApplicantProfileEducation);
    void UpdateUserProfileEducation(ApplicantProfileEducation updatedApplicantProfileEducation);
    void DeleteUserProfileEducation(ApplicantProfileEducation toDeleteApplicantProfileEducation);
}