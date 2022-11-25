using Jobit.API.Security.Resources.Chat;

namespace Jobit.API.Security.Resources;

public class ChatResource
{
    public ApplicantSimpleResource? Applicant { get; set; }
    public RecruiterSimpleResource? Recruiter { get; set; }
    public IList<MessageResource>? Messages { get; set; }
}