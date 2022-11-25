namespace Jobit.API.Jobit.Resources.Show;

//This is the data where you get it.
public class PostJobResource
{
    public long PostJobId { get; set; }
    public string? JobName { get; set; }
    public string? Description { get; set; }
    public float Salary { get; set; }
    public bool Available { get; set; }
    public String? PostJobTitle { get; set; }
    public DateTime DateTime { get; set; }
    public RecruiterPostJobResource? Recruiter { get; set; }
}