using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class ChatResponse: BaseResponse<Chat>
{
    public ChatResponse(Chat resource) : base(resource)
    {
    }

    public ChatResponse(string message) : base(message)
    {
    }
}