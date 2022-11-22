using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IRecruiterProfileService
{
    Task<IEnumerable<RecruiterProfile>> ListRecruiterProfilesByRecruiterIdAsync();
    Task<RecruiterProfileResponse> FindRecruiterProfileByRecruiterId(long recruiterProfileId);
    Task<RecruiterProfileResponse> AddRecruiterProfileAsync(RecruiterProfile newRecruiterProfile);
    Task<RecruiterProfileResponse> UpdateRecruiterProfileAsync(long recruiterId, RecruiterProfile updatedRecruiterProfile);
    Task<RecruiterProfileResponse> DeleteRecruiterProfileAsync(long recruiterId);
    Task SetRecruiterProfileObjects(RecruiterProfile toSetRecruiterProfile);
}