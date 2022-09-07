using Jobit.API.Security.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services;

public interface ICompanyService
{
    Task RegisterCompanyAsync(RegisterCompanyRequest registerCompanyRequest);
}