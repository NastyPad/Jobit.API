using Jobit.API.Security.Resources;

namespace Jobit.API.Jobit.Resources;

public class ProjectResource
{
    public string? ProjectName { get; set; }
    public string? Description { get; set; }
    public string? CodeSource { get; set; }
    public string? ProjectUrl { get; set; }
    public UserResource? User { get; set; }
}