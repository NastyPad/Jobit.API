using Jobit.API.Security.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services.Communication.Responses;

public class ApplicantResponse : BaseResponse<Applicant>
{
    public ApplicantResponse(Applicant resource) : base(resource)
    {
    }

    public ApplicantResponse(string message) : base(message)
    {
    }
}