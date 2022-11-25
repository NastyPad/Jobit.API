namespace Jobit.API.Security.Domain.Services.Communication;

public class RegisterRecruiterRequest : RegisterUserRequest
{
    public long CompanyId { get; set; }
    public String? Ruc { get; set; }
}