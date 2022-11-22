namespace Jobit.API.Jobit.Resources.Bases;

public class ProfileBaseResource
{
    public String? Username { get; set; }
    public String? Firstname { get; set; }
    public String? Lastname { get; set; }
    public bool IsPrivate { get; set; }
    public String? Description { get; set; }
    public String? ProfilePhotoUrl { get; set; }
}