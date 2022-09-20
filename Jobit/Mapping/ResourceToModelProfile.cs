using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Resources;

namespace Jobit.API.Jobit.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<PostTypeResource, PostType>();
        CreateMap<SavePostTypeResource, PostType>();
        CreateMap<JobResource, Job>();
        CreateMap<SaveJobResource, Job>();
        CreateMap<ProjectResource, Project>();
        CreateMap<SaveProjectResource, Project>();
        CreateMap<UpdateProjectResource, Project>();
    }
}