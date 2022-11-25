using Jobit.API.Security.Resources;
using Jobit.API.Security.Resources.Chat;

namespace Jobit.API.Jobit.Resources;

public class ProjectResource
{
    public long ProjectId { get; set; }
    public string? ProjectName { get; set; }
    public string? Description { get; set; }
    public string? CodeSource { get; set; }
    public string? ProjectUrl { get; set; }
    public ApplicantSimpleResource? Applicant { get; set; }
}