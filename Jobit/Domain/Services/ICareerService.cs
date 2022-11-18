using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface ICareerService
{
    Task<IEnumerable<Career>> ListAllCareersAsync();
    Task<CareerResponse> FindCareerByCareerIdAsync(long careerId);
    Task<CareerResponse> AddCareerAsync(Career newCareer);
    Task<CareerResponse> UpdateCareerAsync(long careerId, Career updatedCareer);
    Task<CareerResponse> DeleteCareerAsync(long careerId);
}