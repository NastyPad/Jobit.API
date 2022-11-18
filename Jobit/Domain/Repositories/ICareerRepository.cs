using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface ICareerRepository
{
    Task<IEnumerable<Career>> ListAllCareersAsync();
    Task<Career> FindCareerByCareerIdAsync(long careerId);
    Task AddCareerAsync(Career newCareer);
    void UpdateCareerAsync(Career updatedCareer);
    void DeleteCareerAsync(Career toDeleteCareer);
}