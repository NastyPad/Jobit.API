using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services.Communication.Responses;

public class MessageResponse : BaseResponse<Message>
{
    public MessageResponse(Message resource) : base(resource)
    {
    }

    public MessageResponse(string message) : base(message)
    {
    }
}