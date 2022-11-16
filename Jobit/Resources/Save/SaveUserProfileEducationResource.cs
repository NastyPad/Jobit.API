namespace Jobit.API.Jobit.Resources;

public class SaveUserProfileEducation
{
    public long UserId { get; set; }
    public long EducationId { get; set; }
    public DateTime StartDateTime { get; set;  }
    public DateTime FinishDateTime { get; set; }
}