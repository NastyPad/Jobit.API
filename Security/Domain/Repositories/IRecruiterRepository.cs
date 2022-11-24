using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Security.Domain.Repositories;

public interface IRecruiterRepository
{
    Task<IEnumerable<Recruiter>> ListAllRecruiterAsync();
    Task<Recruiter> FindRecruiterByRecruiterIdAsync(long recruiterId);
    Task RegisterRecruiterAsync(Recruiter newRecruiter);
    void UpdateRecruiterAsync(Recruiter updatedRecruiter);
    void DeleteRecruiterAsync(Recruiter toDeleteRecruiter);
}