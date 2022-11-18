namespace Jobit.API.Jobit.Domain.Models.Intermediate;

public class UserProfileEducation
{
    public long UserProfileEducationId { get; set; }
    public long UserId { get; set; }
    public long EducationId { get; set; }
    public long CareerId { get; set; }
    public Education? Education { get; set; }
    public UserProfile? UserProfile { get; set; }
    public Career? Career { get; set; }
    public DateTime StartDateTime { get; set;  }
    public DateTime FinishDateTime { get; set; }
    


    public void SetUserProfileEducation(UserProfileEducation userProfileEducation)
    {
        UserId = userProfileEducation.UserId;
        EducationId = userProfileEducation.EducationId;
        CareerId = userProfileEducation.CareerId;
        StartDateTime = userProfileEducation.StartDateTime;
        FinishDateTime = userProfileEducation.FinishDateTime;
    }

}