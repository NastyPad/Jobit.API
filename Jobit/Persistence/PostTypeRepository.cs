using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
    
    public async Task AddPostTypeAsync(PostType newPostType)
    {
        await databaseContext.PostTypes.AddAsync(newPostType);
        await databaseContext.SaveChangesAsync();
    }

    public void UpdatePostType(PostType updatedPostType)
    {
        databaseContext.PostTypes.Update(updatedPostType);
    }

    public async Task<PostType?> FindPostTypeByPostTypeId(short postTypeId)
    {
        return await databaseContext.PostTypes
            .FirstOrDefaultAsync(p => p.PostTypeId == postTypeId);
    }

    public void DeletePostTypeByPostTypeId(short postTypeId)
    {
        throw new NotImplementedException();
    }

    public void DeletePostType(PostType postType)
    {
        databaseContext.PostTypes.Remove(postType);
    }
}