using Jobit.API.Security.Resources;

namespace Jobit.API.Jobit.Resources;

public class MessageResource
{
     public long MessageId { get; set; }
    public bool WhoSend { get; set; }
    public string Content { get; set; }

    public ChatResource Chat{get; set;}
}