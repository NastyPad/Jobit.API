namespace Jobit.API.Security.Resources.Generate;

public class SentMessage
{
    public String? MessageContent { get; set; }
    public short WhoSentIt { get; set; }
    public long ApplicantId { get; set; }
    public long RecruiterId { get; set; }
}