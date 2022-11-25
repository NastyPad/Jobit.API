using Jobit.API.Security.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services.Communication.Responses;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(User resource) : base(resource)
    {
    }

    public UserResponse(string message) : base(message)
    {
    }
}