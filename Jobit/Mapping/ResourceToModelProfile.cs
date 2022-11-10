using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Resources;

namespace Jobit.API.Jobit.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePostTypeResource, PostType>();
        CreateMap<SaveJobResource, Job>();
        CreateMap<UpdateJobResource, Job>();
        CreateMap<SaveProjectResource, Project>();
        CreateMap<UpdateProjectResource, Project>();
        CreateMap<UpdateJobRequestResource, JobRequest>();
        CreateMap<SaveJobRequestResource, JobRequest>();
        CreateMap<SaveNotificationResource, Notification>();
        CreateMap<UpdateNotificationResource, Notification>();
        CreateMap<SaveEducationResource, Education>();
        CreateMap<UpdatedEducationResource, Education>();
    }
}