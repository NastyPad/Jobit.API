
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Jobit.API.Jobit.Persistence;

public class EducationRepository: BaseRepository, IEducationRepository
{
    public EducationRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Education>> ListEducationsAsync()
    {
        return await _databaseContext.Educations.ToListAsync();
    }

    public async Task<Education> FindEducationByInstitutionIdAsync(long institutionId)
    {
        return await _databaseContext.Educations.FindAsync(institutionId);
    }

    public async Task AddEducationAsync(Education newEducation)
    {
        await _databaseContext.Educations.AddAsync(newEducation);
    }

    public void UpdateEducation(Education updatedEducation)
    {
        _databaseContext.Educations.Update(updatedEducation);
    }

    public void DeleteEducation(Education toDeleteEducation)
    {
        _databaseContext.Educations.Remove(toDeleteEducation);
    }
}