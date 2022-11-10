using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;
using Jobit.API.Shared.Persistence.Repositories;

namespace Jobit.API.Jobit.Services;

public class EducationService : IEducationService
{
    private readonly IEducationRepository _educationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EducationService(IEducationRepository educationRepository, IUnitOfWork unitOfWork)
    {
        _educationRepository = educationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Education>> ListEducationsAsync()
    {
        return await _educationRepository.ListEducationsAsync();
    }

    public async Task<EducationResponse> FindEducationByEducationIdAsync(long educationId)
    {
        var existingEducation = await _educationRepository.FindEducationByInstitutionIdAsync(educationId);
        if (existingEducation == null)
            return new EducationResponse("Education not found");
        return new EducationResponse(existingEducation);
    }

    public async Task<EducationResponse> AddEducationAsync(Education newEducation)
    {
        try
        {
            await _educationRepository.AddEducationAsync(newEducation);
            await _unitOfWork.CompleteAsync();
            return new EducationResponse(newEducation);
        }
        catch (Exception exception)
        {
            return new EducationResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<EducationResponse> UpdateEducationAsync(long educationId, Education updatedEducation)
    {
        var existingEducation = await _educationRepository.FindEducationByInstitutionIdAsync(educationId);
        if (existingEducation == null)
            return new EducationResponse("Education not found.");
        existingEducation.setEducation(updatedEducation);
        try
        {
            _educationRepository.UpdateEducation(existingEducation);
            await _unitOfWork.CompleteAsync();
            return new EducationResponse(existingEducation);
        }
        catch (Exception exception)
        {
            return new EducationResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<EducationResponse> DeleteEducationAsync(long educationId)
    {
        var existingEducation = await _educationRepository.FindEducationByInstitutionIdAsync(educationId);
        if (existingEducation == null)
            return new EducationResponse("Education not found.");
        try
        {
            _educationRepository.DeleteEducation(existingEducation);
            await _unitOfWork.CompleteAsync();
            return new EducationResponse(existingEducation);
        }
        catch (Exception exception)
        {
            return new EducationResponse($"An error has occurred: {exception.Message}");
        }
    }
}