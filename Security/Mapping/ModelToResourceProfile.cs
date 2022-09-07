
using AutoMapper;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Resources;

namespace Jobit.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
    }
}