using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Resources;

namespace Jobit.API.Jobit.Resources;

//This is the data where you get it.
public class ChatResource
{
    public long ChatId { get; set; }


    public RecruiterResource Recruiter {get; set;}

    public ApplicantResource Applicant {get; set;}

}