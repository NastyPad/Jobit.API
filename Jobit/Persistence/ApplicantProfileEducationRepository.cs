using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class ApplicantProfileEducationRepository : BaseRepository, IApplicantProfileEducationRepository
{
    public ApplicantProfileEducationRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<ApplicantProfileEducation> FindUserProfileEducationByUserProfileEducationId(long userProfileEducationId)
    {
        return await _databaseContext.ApplicantProfileEducations.FindAsync(userProfileEducationId);
    }

    public async Task<IEnumerable<ApplicantProfileEducation>> ListUserProfileEducations()
    {
        return await _databaseContext.ApplicantProfileEducations.ToListAsync();
    }

    public async Task<IEnumerable<ApplicantProfileEducation>> ListUserProfileEducationsByUserIdAsync(long userId)
    {
        return await _databaseContext.ApplicantProfileEducations.Where(p => p.ApplicantId == userId).ToListAsync();
    }

    public async Task AddUserProfileEducationAsync(ApplicantProfileEducation newApplicantProfileEducation)
    {
        await _databaseContext.ApplicantProfileEducations.AddAsync(newApplicantProfileEducation);
    }

    public void UpdateUserProfileEducation(ApplicantProfileEducation updatedApplicantProfileEducation)
    {
        _databaseContext.ApplicantProfileEducations.AddAsync(updatedApplicantProfileEducation);
    }

    public void DeleteUserProfileEducation(ApplicantProfileEducation toDeleteApplicantProfileEducation)
    {
        _databaseContext.ApplicantProfileEducations.Remove(toDeleteApplicantProfileEducation);
    }
}