using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services;

public interface ICompanyService
{
    Task<IEnumerable<Company>> ListCompaniesAsync();
    Task RegisterCompanyAsync(RegisterCompanyRequest registerCompanyRequest);
}