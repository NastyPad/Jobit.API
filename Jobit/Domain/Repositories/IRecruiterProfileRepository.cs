using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IRecruiterProfileRepository
{
    Task<IEnumerable<RecruiterProfile>> ListRecruiterProfilesAsync();
    Task<RecruiterProfile> FindRecruiterProfileByRecruiterIdAsync(long recruiterId);
    Task AddRecruiterProfileAsync(RecruiterProfile newRecruiterProfile);
    void UpdateRecruiterProfile(RecruiterProfile updatedRecruiterProfile);
    void DeleteRecruiterProfile(RecruiterProfile toDeleteRecruiterProfile);
}