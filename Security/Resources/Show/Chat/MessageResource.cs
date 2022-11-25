namespace Jobit.API.Security.Resources;

public class MessageResource
{
    public short WhoSentIt { get; set; }
    public String? MessageContent { get; set; }
    public DateTime TimeSent { get; set; }
}