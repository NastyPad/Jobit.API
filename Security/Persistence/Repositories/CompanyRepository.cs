
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Security.Persistence.Repositories;

public class CompanyRepository : BaseRepository, ICompanyRepository
{
    public CompanyRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Company>> ListCompaniesAsync()
    {
        return await _databaseContext.Companies.ToListAsync();
    }

    public async Task AddCompanyAsync(Company company)
    {
        await _databaseContext.Companies.AddAsync(company);
    }

    public async Task<Company> FindCompanyByCompanyIdAsync(long companyId)
    {
        return await _databaseContext.Companies.FindAsync(companyId);
    }

    public void DeleteCompanyAsync(Company company)
    {
        _databaseContext.Companies.Remove(company);
    }

    public void UpdateCompanyAsync(Company company)
    {
        _databaseContext.Companies.Update(company);
    }
    
}
