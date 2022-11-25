using Jobit.API.Security.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class CompanyResponse: BaseResponse<Company>
{
    public CompanyResponse(Company resource) : base(resource)
    {
    }

    public CompanyResponse(string message) : base(message)
    {
    }
}