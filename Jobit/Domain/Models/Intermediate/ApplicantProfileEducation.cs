namespace Jobit.API.Jobit.Domain.Models.Intermediate;

public class ApplicantProfileEducation
{
    public long ApplicantProfileEducationId { get; set; }
    public long ApplicantId { get; set; }
    public long EducationId { get; set; }
    public long CareerId { get; set; }
    public Education? Education { get; set; }
    public ApplicantProfile? ApplicantProfile { get; set; }
    public Career? Career { get; set; }
    public DateTime StartDateTime { get; set;  }
    public DateTime FinishDateTime { get; set; }
    


    public void SetUserProfileEducation(ApplicantProfileEducation applicantProfileEducation)
    {
        ApplicantId = applicantProfileEducation.ApplicantId;
        EducationId = applicantProfileEducation.EducationId;
        CareerId = applicantProfileEducation.CareerId;
        StartDateTime = applicantProfileEducation.StartDateTime;
        FinishDateTime = applicantProfileEducation.FinishDateTime;
    }

}