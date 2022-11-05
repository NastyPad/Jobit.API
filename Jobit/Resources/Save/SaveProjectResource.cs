namespace Jobit.API.Jobit.Resources;

public class SaveProjectResource
{
    public string? ProjectName { get; set; }
    public string? Description { get; set; }
    public string? CodeSource { get; set; }
    public string? ProjectUrl { get; set; }
    public long UserId { get; set; } //Foreign
}