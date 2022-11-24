using Jobit.API.Security.Resources.Chat;

namespace Jobit.API.Security.Resources;

public class ChatResource
{
    public ApplicantChatResource? Applicant { get; set; }
    public RecruiterChatResource? Recruiter { get; set; }
    public IList<MessageResource>? Messages { get; set; }
}