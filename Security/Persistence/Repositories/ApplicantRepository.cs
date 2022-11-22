using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Security.Persistence.Repositories;

public class ApplicantRepository : BaseRepository, IApplicantRepository
{
    public ApplicantRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Applicant>> ListAllApplicantsAsync()
    {
        return await _databaseContext.Applicants.ToListAsync();
    }

    public async Task<Applicant> FindApplicantByApplicantIdAsync(long applicantId)
    {
        return await _databaseContext.Applicants.FindAsync(applicantId);
    }

    public async Task RegisterApplicantAsync(Applicant newApplicant)
    {
        await _databaseContext.Applicants.AddAsync(newApplicant);
    }

    public void DeleteApplicantAsync(Applicant toDeleteApplicant)
    {
        _databaseContext.Applicants.Update(toDeleteApplicant);
    }

    public void UpdateApplicantAsync(Applicant updatedApplicant)
    {
        _databaseContext.Applicants.Remove(updatedApplicant);
    }
}