using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class PostTypeResponse : BaseResponse<PostType>
{
    public PostTypeResponse(PostType resource) : base(resource)
    {
    }

    public PostTypeResponse(string message) : base(message)
    {
    }
}