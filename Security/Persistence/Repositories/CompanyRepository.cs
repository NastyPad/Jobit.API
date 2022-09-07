using System.Data.Entity;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;

namespace Jobit.API.Security.Persistence.Repositories;

public class CompanyRepository : BaseRepository, ICompanyRepository
{
    public CompanyRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Company>> ListCompaniesAsync()
    {
        return await databaseContext.Companies.ToListAsync();
    }

    public async Task AddCompanyAsync(Company company)
    {
        await databaseContext.Companies.AddAsync(company);
    }

    public async Task<Company> FindByCompanyIdAsync(int companyId)
    {
        return await databaseContext.Companies.FindAsync(companyId);
    }
}
