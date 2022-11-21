
namespace Jobit.API.Jobit.Resources;

public class SaveMessageResource
{
    public bool WhoSend { get; set; }
    public string Content { get; set; }

    public long ChatId {get; set;}
}