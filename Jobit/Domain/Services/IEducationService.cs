using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IEducationService
{
    Task<IEnumerable<Education>> ListEducationsAsync(); 
    Task<EducationResponse> FindEducationByEducationIdAsync(long educationId);
    Task<EducationResponse> AddEducationAsync(Education newEducation);
    Task<EducationResponse> UpdateEducationAsync(long educationId, Education updatedEducation);
    Task<EducationResponse> DeleteEducationAsync(long educationId);
}