namespace Jobit.API.Jobit.Resources;

public class ApplicantProfileEducationResource
{
    public long UserProfileEducationId { get; set; }
    public EducationResource? Education { get; set; }
    public CareerResource? Career { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime FinishDateTime { get; set; }
}