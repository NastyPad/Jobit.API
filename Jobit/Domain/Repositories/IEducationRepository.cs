using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IEducationRepository
{
    Task<IEnumerable<Education>> ListEducationsAsync();
    Task<Education> FindEducationByInstitutionIdAsync(long institutionId);
    Task AddEducationAsync(Education newEducation);
    void UpdateEducation(Education updatedEducation);
    void DeleteEducation(Education toDeleteEducation);
    
}