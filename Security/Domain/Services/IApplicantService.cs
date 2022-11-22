using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services.Communication;
using Jobit.API.Security.Domain.Services.Communication.Responses;

namespace Jobit.API.Security.Domain.Services;

public interface IApplicantService
{
    Task<IEnumerable<Applicant>> ListAllApplicantsAsync();
    Task<ApplicantResponse> FindApplicantByApplicantIdAsync(long applicantId);
    Task<ApplicantResponse> RegisterApplicantAsync(RegisterApplicantRequest newApplicant);
    Task<ApplicantResponse> UpdateApplicantAsync(long applicantId, Applicant updatedApplicant);
    Task<ApplicantResponse> DeleteApplicantAsync(long applicantId);
    Task<Object> GetApplicantPublicData(long applicantId);
    Task GenerateApplicantProfileAsync(long applicantId);
}