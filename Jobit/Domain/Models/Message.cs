using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class Message
{
    public long MessageId { get; set; }
    public bool WhoSend { get; set; }
    public string Content { get; set; }

    public long ChatId {get; set;}
    public Chat? Chat{get; set;}
}