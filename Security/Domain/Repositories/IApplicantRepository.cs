using System.Collections;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Security.Domain.Repositories;

public interface IApplicantRepository
{
    Task<IEnumerable<Applicant>> ListAllApplicantsAsync();
    Task<Applicant> FindApplicantByApplicantIdAsync(long applicantId);
    Task RegisterApplicantAsync(Applicant newApplicant);
    void DeleteApplicantAsync(Applicant toDeleteApplicant);
    void UpdateApplicantAsync(Applicant updatedApplicant);
}