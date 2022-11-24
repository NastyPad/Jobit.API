namespace Jobit.API.Security.Domain.Models.Chat;

public class Message
{
    public long MessageId { get; set; }
    public String? MessageContent { get; set; }
    public short WhoSentIt { get; set; } //Improve for api v2 (applicant 1 and recruiter 2)
    public DateTime TimeSent { get; set; }

    //Relations
    //Applicant
    public long ApplicantId { get; set; } //Primary key and foreign 
    public Applicant? Applicant { get; set; }

    //Recruiter
    public long RecruiterId { get; set; } //Primary key and foreign
    public Recruiter? Recruiter { get; set; }

    //Relations One to Many (this class has less cardinality)
    public Chat? Chat { get; set; }


    public void SetMessage(Message message)
    {
        MessageContent = message.MessageContent;
    }
}