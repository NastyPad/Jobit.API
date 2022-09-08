using AutoMapper;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Resources;

namespace Jobit.API.Security.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<UserResource, User>();
        CreateMap<CompanyResource, Company>();
    }
}