using Jobit.API.Security.Resources.Bases;

namespace Jobit.API.Security.Resources;

public class RecruiterResource : UserBaseResource
{
    public long RecruiterId { get; set; }
}