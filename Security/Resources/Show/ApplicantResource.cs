using Jobit.API.Security.Resources.Bases;

namespace Jobit.API.Security.Resources;

public class ApplicantResource : UserBaseResource
{
    public long ApplicantId { get; set; }
}