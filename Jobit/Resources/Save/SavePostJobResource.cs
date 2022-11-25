namespace Jobit.API.Jobit.Resources;

public class SavePostJobResource
{
    public string? JobName { get; set; }
    public string? Description { get; set; }
    public float Salary { get; set; }
    public bool Available { get; set; }
    public long RecruiterId { get; set; }
    public String? PostJobTitle { get; set; }
    public DateTime DateTime { get; set; }
}