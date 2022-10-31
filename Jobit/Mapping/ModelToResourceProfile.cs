using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Resources;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<PostType, PostTypeResource>();
        CreateMap<PostType, SavePostTypeResource>();
        CreateMap<Job, JobResource>();
        CreateMap<Job, SaveJobResource>();
        CreateMap<Job, UpdateJobResource>();
        CreateMap<Project, ProjectResource>();
        CreateMap<Project, SaveProjectResource>();
        CreateMap<Project, UpdateProjectResource>();
        CreateMap<JobRequest, JobRequestResource>();
        CreateMap<JobRequest, UpdateJobRequestResource>();
        CreateMap<JobRequest, SaveJobRequestResource>();
        CreateMap<Notification, NotificationResource>();
    }
}