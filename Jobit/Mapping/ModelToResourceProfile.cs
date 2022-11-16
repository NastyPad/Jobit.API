using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Resources;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<PostType, PostTypeResource>();
        CreateMap<Job, JobResource>();
        CreateMap<Project, ProjectResource>();
        CreateMap<JobRequest, JobRequestResource>();
        CreateMap<Notification, NotificationResource>();
        CreateMap<TechSkill, TechSkillResource>();
        CreateMap<UserProfile, UserProfileResource>();
        CreateMap<UserProfileTechSkill, UserProfileTechSkillResource>();
        CreateMap<Education, EducationResource>();
        CreateMap<UserProfileEducation, UserProfileEducationResource>();
    }
}