using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class EducationResponse: BaseResponse<Education>
{
    public EducationResponse(Education resource) : base(resource)
    {
    }

    public EducationResponse(string message) : base(message)
    {
    }
}