using AutoMapper;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication;

namespace Jobit.API.Security.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
    }

    public async Task<IEnumerable<Company>> ListCompaniesAsync()
    {
        return await _companyRepository.ListCompaniesAsync();
    }

    public Task<Company> GetCompanyByCompanyId(long companyId)
    {
        throw new NotImplementedException();
    }

    public async Task RegisterCompanyAsync(RegisterCompanyRequest registerCompanyRequest)
    {
        throw new NotImplementedException();
    }
}