using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class UserProfile
{
    public String? Firstname { get; set; }
    public String? Lastname { get; set; }
    public String? Username { get; set; }
    public String? Gender { get; set; }
    public String? Description { get; set; }
    public Boolean IsPrivate { get; set; }
    public String? ProfilePhotoUrl { get; set; }
    public IList<UserProfileTechSkill> UserProfileTechSkills { get; set; }

    public IList<UserProfileEducation> UserProfileEducations { get; set; }
    //public IList<TechSkill> TechSkills { get; set; }


    //Relationships - Foreignkey and PrimaryKey
    public long UserId { get; set; }
    
    //Relatiionships - Object
    public User User { get; set; }


    public UserProfile()
    {
    }

    public UserProfile(long userId, String description, String profilePhotoUrl, bool isPrivate, String gender)
    {
        ProfilePhotoUrl = profilePhotoUrl;
        UserId = userId;
        Description = description;
        IsPrivate = isPrivate;
        Gender = gender;
    }

    public UserProfile(String? username, String? firstname, String? lastname, long userId)
    {
        UserId = userId;
        Username = username;
        Firstname = firstname;
        Lastname = lastname;
        ProfilePhotoUrl = "";
        Description = "";
        IsPrivate = false;
        Gender = "Not Defined";
    }

    public void SetDefaultProfile()
    {
        Description = "";
        IsPrivate = true;
    }

    public void SetUserProfile(UserProfile userProfile)
    {
        Username = userProfile.Username;
        Firstname = userProfile.Firstname;
        Lastname = userProfile.Lastname;
        ProfilePhotoUrl = userProfile.ProfilePhotoUrl;
        Description = userProfile.Description;
        IsPrivate = userProfile.IsPrivate;
        Gender = userProfile.Gender;
    }
}
