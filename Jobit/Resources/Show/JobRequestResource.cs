using Jobit.API.Jobit.Resources.Show;
using Jobit.API.Security.Resources;
using Jobit.API.Security.Resources.Chat;

namespace Jobit.API.Jobit.Resources;

public class JobRequestResource
{
    public long RequestId { get; set; }
    public ApplicantSimpleResource Applicant { get; set; }
    public PostJobResource PostJob { get; set; }
}