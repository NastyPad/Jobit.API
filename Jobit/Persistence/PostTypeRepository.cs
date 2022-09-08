using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class PostTypeRepository : BaseRepository, IPostTypeRepository
{
    public PostTypeRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<PostType>> ListPostTypesAsync()
    {
        return await databaseContext.PostTypes.ToListAsync();
    }

    public async Task AddJobAsync(Job newJob)
    {
        await databaseContext.AddAsync(newJob);
    }
}