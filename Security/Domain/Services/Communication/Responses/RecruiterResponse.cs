using Jobit.API.Security.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services.Communication.Responses;

public class RecruiterResponse: BaseResponse<Recruiter>
{
    public RecruiterResponse(Recruiter resource) : base(resource)
    {
    }

    public RecruiterResponse(string message) : base(message)
    {
    }
}