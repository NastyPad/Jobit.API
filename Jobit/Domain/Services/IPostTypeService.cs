using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Services;

public interface IPostTypeService
{ 
    Task<IEnumerable<PostType>> ListPostTypesAsync();
}