namespace Jobit.API.Jobit.Resources.Save;

public class SaveProjectResource
{
    public string? ProjectName { get; set; }
    public string? Description { get; set; }
    public string? CodeSource { get; set; }
    public string? ProjectUrl { get; set; }
    public long ApplicantId { get; set; } //Foreign
}