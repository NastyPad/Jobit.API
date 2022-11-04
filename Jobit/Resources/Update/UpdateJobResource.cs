namespace Jobit.API.Jobit.Resources;

public class UpdateJobResource
{
    public string? JobName { get; set; }
    public string? Description { get; set; }
    public float Salary { get; set; }
    public bool Available { get; set; }
}