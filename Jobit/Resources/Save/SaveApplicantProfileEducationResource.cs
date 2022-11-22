namespace Jobit.API.Jobit.Resources;

public class SaveApplicantProfileEducationResource
{
    public long CareerId { get; set; }
    public long UserId { get; set; }
    public long EducationId { get; set; }
    public DateTime StartDateTime { get; set;  }
    public DateTime FinishDateTime { get; set; }
}