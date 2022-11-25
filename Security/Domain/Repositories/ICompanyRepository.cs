using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Security.Domain.Repositories;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> ListCompaniesAsync();
    Task AddCompanyAsync(Company company);
    Task<Company> FindCompanyByCompanyIdAsync(long companyId);
    void DeleteCompanyAsync(Company company);
    void UpdateCompanyAsync(Company company);
}