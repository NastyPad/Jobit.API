using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Jobit.API.Jobit.Services;

public class PostTypeService : IPostTypeService
{
    //Remember that in services, we use repo.
    private readonly IPostTypeRepository _postTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PostTypeService( IPostTypeRepository postTypeRepository, IUnitOfWork unitOfWork)
    {
        _postTypeRepository = postTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PostType>> ListPostTypesAsync()
    {
        return await _postTypeRepository.ListPostTypesAsync();
    }

    public async Task AddPostTypeAsync(PostType newPostType)
    {
        await _postTypeRepository.AddPostTypeAsync(newPostType);
    }

    //Change this to async.
    public async Task<PostTypeResponse> UpdatePostType(int postTypeId, PostType updatedPostType)
    {
        var existencePostType = await _postTypeRepository.FindPostTypeByPostTypeId(postTypeId);
        if(existencePostType == null)
            return new PostTypeResponse("Not found.");
        
        existencePostType.Name = updatedPostType.Name;
        _postTypeRepository.UpdatePostType(updatedPostType);
        await _unitOfWork.CompleteAsync();
        return new PostTypeResponse("Successfully updated.");
    }

    public async Task<PostTypeResponse> DeletePostType(int postTypeId)
    {
        var existingPostType = await _postTypeRepository.FindPostTypeByPostTypeId(postTypeId);
        if (existingPostType == null)
            return new PostTypeResponse("Sorry, but the element does not exist!");
        _postTypeRepository.DeletePostType(existingPostType);
        await _unitOfWork.CompleteAsync();
        return new PostTypeResponse("Element deleted successfully");
    }
}