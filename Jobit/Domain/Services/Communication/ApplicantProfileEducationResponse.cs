using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class UserProfileEducationResponse: BaseResponse<ApplicantProfileEducation>
{
    public UserProfileEducationResponse(ApplicantProfileEducation resource) : base(resource)
    {
    }

    public UserProfileEducationResponse(string message) : base(message)
    {
    }
}