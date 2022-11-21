using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class MessageResponse : BaseResponse<Message>
{
    public MessageResponse(Message resource) : base(resource)
    {
    }

    public MessageResponse(string message) : base(message)
    {
    }
}