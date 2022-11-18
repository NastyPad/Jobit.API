using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class CareerRepository : BaseRepository, ICareerRepository
{
    public CareerRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Career>> ListAllCareersAsync()
    {
        return await _databaseContext.Careers.ToListAsync();
    }

    public async Task<Career> FindCareerByCareerIdAsync(long careerId)
    {
        return await _databaseContext.Careers.FindAsync(careerId);
    }

    public async Task AddCareerAsync(Career newCareer)
    {
        await _databaseContext.Careers.AddAsync(newCareer);
    }

    public void UpdateCareerAsync(Career updatedCareer)
    {
        _databaseContext.Careers.Update(updatedCareer);
    }

    public void DeleteCareerAsync(Career toDeleteCareer)
    {
        _databaseContext.Careers.Remove(toDeleteCareer);
    }
}