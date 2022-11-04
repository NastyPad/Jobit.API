using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class TechSkillService: ITechSkillService
{
    private readonly ITechSkillRepository _techSkillRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TechSkillService(ITechSkillRepository techSkillRepository, IUnitOfWork unitOfWork)
    {
        _techSkillRepository = techSkillRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<TechSkill>> LisTechSkillsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TechSkillResponse> FindTechSkillByTechSkillIdAsync(long techSkillId)
    {
        throw new NotImplementedException();
    }

    public Task<TechSkillResponse> AddTechSkillAsync(TechSkill newTechSkill)
    {
        throw new NotImplementedException();
    }

    public Task<TechSkillResponse> UpdateTechSkillAsync(long techSkillId, TechSkill updatedTechSkill)
    {
        throw new NotImplementedException();
    }

    public Task<TechSkillResponse> DeleteTechSkillAsync(long techSkillId)
    {
        throw new NotImplementedException();
    }
}