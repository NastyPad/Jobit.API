using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Resources;

namespace Jobit.API.Jobit.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<PostType, PostTypeResource>();
        CreateMap<PostType, SavePostTypeResource>();
        CreateMap<Job, JobResource>();
        CreateMap<Project, ProjectResource>();
        CreateMap<Project, SaveProjectResource>();
    }
}