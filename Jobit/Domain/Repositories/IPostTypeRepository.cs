using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IPostTypeRepository
{
    Task<IEnumerable<PostType>> ListPostTypesAsync();
    Task AddJobAsync(Job newJob);
}