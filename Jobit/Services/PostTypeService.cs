using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class PostTypeService : IPostTypeService
{
    //Remember that in services, we use repo.
    private readonly IPostTypeRepository _postTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PostTypeService(IPostTypeRepository postTypeRepository, IUnitOfWork unitOfWork)
    {
        _postTypeRepository = postTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PostType>> ListPostTypesAsync()
    {
        return await _postTypeRepository.ListPostTypesAsync();
    }
}