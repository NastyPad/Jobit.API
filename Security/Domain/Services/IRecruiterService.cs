using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services.Communication;
using Jobit.API.Security.Domain.Services.Communication.Responses;
using Jobit.API.Security.Resources;

namespace Jobit.API.Security.Domain.Services;

public interface IRecruiterService
{
    Task<IEnumerable<Recruiter>> ListAllRecruitersAsync();
    Task<RecruiterResponse> FindRecruiterByRecruiterIdAsync(long recruiterId);
    Task<RecruiterResponse> RegisterRecruiterAsync(RegisterRecruiterRequest newRecruiter);
    Task<RecruiterResponse> UpdateRecruiterAsync(long recruiterId, Recruiter updatedRecruiter);
    Task<RecruiterResponse> DeleteRecruiterAsync(long recruiterId);
    
    Task GenerateRecruiterProfileAsync(long applicantId);
}