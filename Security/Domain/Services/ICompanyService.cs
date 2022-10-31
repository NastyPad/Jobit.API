using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services;

public interface ICompanyService
{
    Task<IEnumerable<Company>> ListCompaniesAsync();

    Task<Company> GetCompanyByCompanyId(long companyId);
    
    Task RegisterCompanyAsync(RegisterCompanyRequest registerCompanyRequest);
    

}