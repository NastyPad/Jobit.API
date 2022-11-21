using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class Chat
{
    public long ChatId { get; set; }


    public long RecruiterId { get; set; }
    public Recruiter? Recruiter {get; set;}


    public long ApplicantId { get; set; }
    public Applicant? Applicant {get; set;}


    public IList<Message> Messages { get; set; }
}