namespace Jobit.API.Jobit.Resources;

public class UpdatedUserProfileResource
{
    public String? Firstname { get; set; }
    public String? Lastname { get; set; }
    public String? Username { get; set; }
    public String? Gender { get; set; }
    public String? Description { get; set; }
    public Boolean IsPrivate { get; set; }
    public String? ProfilePhotoUrl { get; set; }
}