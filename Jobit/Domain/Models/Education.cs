using Jobit.API.Jobit.Domain.Models.Intermediate;

namespace Jobit.API.Jobit.Domain.Models;

public class Education
{
    public long EducationId { get; set; }
    public String EducationName { get; set; }
    public String PhotoUrl { get; set; }
    public String AbbreviatedEducationName { get; set; }
    public IList<ApplicantProfileEducation> ApplicantProfileEducations { get; set; }

    public void setEducation(Education education)
    {
        EducationName = education.EducationName;
        PhotoUrl = education.PhotoUrl;
        AbbreviatedEducationName = education.AbbreviatedEducationName;
    }
}