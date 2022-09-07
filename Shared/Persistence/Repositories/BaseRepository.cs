using Jobit.API.Shared.Persistence.Context;

namespace Jobit.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDatabaseContext databaseContext;

    public BaseRepository(AppDatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }
}