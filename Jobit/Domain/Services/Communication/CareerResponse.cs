using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class CareerResponse : BaseResponse<Career>
{
    public CareerResponse(Career resource) : base(resource)
    {
    }

    public CareerResponse(string message) : base(message)
    {
    }
}

