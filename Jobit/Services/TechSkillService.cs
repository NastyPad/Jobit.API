using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class TechSkillService : ITechSkillService
{
    private readonly ITechSkillRepository _techSkillRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TechSkillService(ITechSkillRepository techSkillRepository, IUnitOfWork unitOfWork)
    {
        _techSkillRepository = techSkillRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TechSkill>> ListTechSkillsAsync()
    {
        return await _techSkillRepository.ListTechSkillAsync();
    }

    public async Task<TechSkillResponse> FindTechSkillByTechSkillIdAsync(long techSkillId)
    {
        var existingTechSkill = await _techSkillRepository.FindTechSkillByTechSkillIdAsync(techSkillId);
        if (existingTechSkill == null)
            return new TechSkillResponse("Not found");
        try
        {
            return new TechSkillResponse(existingTechSkill);
        }
        catch (Exception exception)
        {
            return new TechSkillResponse($"An error has ocurred:{exception.Message}");
        }
    }

    public async Task<TechSkillResponse> AddTechSkillAsync(TechSkill newTechSkill)
    {
        try
        {
            await _techSkillRepository.AddTechSkillAsync(newTechSkill);
            await _unitOfWork.CompleteAsync();
            return new TechSkillResponse(newTechSkill);
        }
        catch (Exception exception)
        {
            return new TechSkillResponse($"An error has ocurred:{exception.Message}");
        }
    }

    public async Task<TechSkillResponse> UpdateTechSkillAsync(long techSkillId, TechSkill updatedTechSkill)
    {
        var existingTechSkill = await _techSkillRepository.FindTechSkillByTechSkillIdAsync(techSkillId);
        if (existingTechSkill == null)
            return new TechSkillResponse("Not found");
        
        // Updating TechSkill attributes
        existingTechSkill.SetTechSkill(updatedTechSkill);
        
        try
        {
            _techSkillRepository.UpdateTechSkill(existingTechSkill);
            await _unitOfWork.CompleteAsync();
            return new TechSkillResponse(existingTechSkill);
        }
        catch (Exception exception)
        {
            return new TechSkillResponse($"An error has ocurred:{exception.Message}");
        }
    }

    public async Task<TechSkillResponse> DeleteTechSkillAsync(long techSkillId)
    {
        var existingTechSkill = await _techSkillRepository.FindTechSkillByTechSkillIdAsync(techSkillId);
        if (existingTechSkill == null)
            return new TechSkillResponse("Not found");

        try
        {
            _techSkillRepository.DeleteTechSkill(existingTechSkill);
            await _unitOfWork.CompleteAsync();
            return new TechSkillResponse(existingTechSkill);
        }
        catch (Exception exception)
        {
            return new TechSkillResponse($"An error has ocurred:{exception.Message}");
        }
    }
}