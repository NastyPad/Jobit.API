using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class UserProfileResponse: BaseResponse<ApplicantProfile>
{
    public UserProfileResponse(ApplicantProfile resource) : base(resource)
    {
    }

    public UserProfileResponse(string message) : base(message)
    {
    }
}