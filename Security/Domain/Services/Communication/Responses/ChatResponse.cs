using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services.Communication.Responses;

public class ChatResponse : BaseResponse<Chat>
{
    public ChatResponse(Chat resource) : base(resource)
    {
    }

    public ChatResponse(string message) : base(message)
    {
    }
}