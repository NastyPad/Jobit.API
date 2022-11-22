using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class RecruiterProfileResponse : BaseResponse<RecruiterProfile>
{
    public RecruiterProfileResponse(RecruiterProfile resource) : base(resource)
    {
    }

    public RecruiterProfileResponse(string message) : base(message)
    {
    }
}