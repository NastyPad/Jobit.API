namespace Jobit.API.Jobit.Resources;

public class UserProfileEducationResource
{
    public long UserProfileEducationId { get; set; }
    public long EducationId { get; set; }
    public EducationResource? Education { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime FinishDateTime { get; set; }
}