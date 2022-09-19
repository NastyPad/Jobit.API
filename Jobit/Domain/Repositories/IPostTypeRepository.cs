using Jobit.API.Jobit.Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IPostTypeRepository
{
    Task<IEnumerable<PostType>> ListPostTypesAsync();
    Task AddPostTypeAsync(PostType newPostType);
    void UpdatePostType(PostType updatedPostType);
    Task<PostType?> FindPostTypeByPostTypeId(int postTypeId);
    void DeletePostType(PostType toDeletePostType);
}