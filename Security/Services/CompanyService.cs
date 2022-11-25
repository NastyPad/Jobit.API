using AutoMapper;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Security.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CompanyService(ICompanyRepository companyRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Company>> ListCompaniesAsync()
    {
        return await _companyRepository.ListCompaniesAsync();
    }

    public async Task<CompanyResponse> GetCompanyByCompanyId(long companyId)
    {
        var existingCompany = await _companyRepository.FindCompanyByCompanyIdAsync(companyId);
        if (existingCompany == null)
            return new CompanyResponse("Company does not exist");
        return new CompanyResponse(existingCompany);
    }

    public async Task<CompanyResponse> RegisterCompanyAsync(RegisterCompanyRequest registerCompanyRequest)
    {
        var mappedCompany = _mapper.Map<RegisterCompanyRequest, Company>(registerCompanyRequest);
        try
        {
            
            await _companyRepository.AddCompanyAsync(mappedCompany);
            await _unitOfWork.CompleteAsync();
            return new CompanyResponse(mappedCompany);
        }
        catch (Exception exception)
        {
            return new CompanyResponse($"An error has ocurred { exception.Message }");
        }
    }
}