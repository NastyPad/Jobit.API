using Jobit.API.Shared.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;

namespace Jobit.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDatabaseContext _context;
    
    public UnitOfWork(AppDatabaseContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync(); //Save changes in database!
    }
}