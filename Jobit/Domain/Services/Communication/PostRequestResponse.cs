using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class JobRequestResponse : BaseResponse<JobRequest>
{
    protected JobRequestResponse(JobRequest resource) : base(resource)
    {
    }

    protected JobRequestResponse(string message) : base(message)
    {
    }
}