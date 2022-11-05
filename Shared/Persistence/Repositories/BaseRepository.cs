using Jobit.API.Shared.Persistence.Context;

namespace Jobit.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDatabaseContext _databaseContext;

    public BaseRepository(AppDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
}