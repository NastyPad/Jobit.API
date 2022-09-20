using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Jobit.Resources;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Jobit.API.Jobit.Domain.Services;

public interface IPostTypeService
{ 
    Task<IEnumerable<PostType>> ListPostTypesAsync();
    Task AddPostTypeAsync(PostType newPostType);
    Task<PostTypeResponse> UpdatePostTypeAsync(int id, PostType updatedPostType);
    Task<PostTypeResponse> DeletePostTypeAsync(int postTypeId);
}