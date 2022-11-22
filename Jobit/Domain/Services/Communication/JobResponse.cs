using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class JobResponse: BaseResponse<PostJob>
{
    public JobResponse(PostJob resource) : base(resource)
    {
    }

    public JobResponse(string message) : base(message)
    {
    }
}