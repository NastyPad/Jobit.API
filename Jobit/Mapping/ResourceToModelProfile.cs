using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Resources;

namespace Jobit.API.Jobit.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePostTypeResource, PostType>();
        
        CreateMap<UpdateJobResource, Job>();
        CreateMap<SaveJobResource, Job>();
        
        CreateMap<UpdateProjectResource, Project>();
        CreateMap<SaveProjectResource, Project>();
        
        CreateMap<UpdateJobRequestResource, JobRequest>();
        CreateMap<SaveJobRequestResource, JobRequest>();
        
        CreateMap<UpdateNotificationResource, Notification>();
        CreateMap<SaveNotificationResource, Notification>();
        
        CreateMap<UpdatedEducationResource, Education>();
        CreateMap<SaveEducationResource, Education>();
        
        CreateMap<UpdatedUserProfileResource, UserProfile>();

        CreateMap<UpdateUserProfileTechSkillResource, UserProfile>();
        CreateMap<SaveUserProfileTechSkillResource, UserProfile>();
        
        CreateMap<UpdatedUserProfileEducation, UserProfileEducation>();
        CreateMap<SaveUserProfileEducation, UserProfileEducation>();
    }
}