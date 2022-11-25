using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services;

public interface ICompanyService
{
    Task<IEnumerable<Company>> ListCompaniesAsync();
    Task<CompanyResponse> GetCompanyByCompanyId(long companyId);
    Task<CompanyResponse> RegisterCompanyAsync(RegisterCompanyRequest registerCompanyRequest);
    

}