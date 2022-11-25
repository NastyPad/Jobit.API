namespace Jobit.API.Security.Domain.Services.Communication;

public class RegisterCompanyRequest
{
    public string? CompanyName { get; set; }
    public string? Password { get; set; }
    public string? ProfilePhotoUrl { get; set;  }
    public string? CompanyEmail { get; set; }
    public string? Description { get; set; }
}