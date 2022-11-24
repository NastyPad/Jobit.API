namespace Jobit.API.Security.Domain.Models.Chat;

public class Chat
{
    //Relationships
    //Applicant
    public long ApplicantId { get; set; } //Primary key and foreign
    public Applicant? Applicant { get; set; }

    //Recruiter
    public long RecruiterId { get; set; } //Primary key and foreign
    public Recruiter? Recruiter { get; set; }
    
    //Relation one to many (this class has more cardinality)
    public IList<Message> Messages { get; set; }
    
}