using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Resources;

namespace Jobit.API.Jobit.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {

        CreateMap<UpdatePostJobResource, PostJob>();
        CreateMap<SavePostJobResource, PostJob>();
        
        CreateMap<UpdateProjectResource, Project>();
        CreateMap<SaveProjectResource, Project>();
        
        CreateMap<UpdateJobRequestResource, JobRequest>();
        CreateMap<SaveJobRequestResource, JobRequest>();
        
        CreateMap<UpdateNotificationResource, Notification>();
        CreateMap<SaveNotificationResource, Notification>();
        
        CreateMap<UpdatedEducationResource, Education>();
        CreateMap<SaveEducationResource, Education>();
        
        CreateMap<UpdatedUserProfileResource, ApplicantProfile>();

        CreateMap<UpdateUserProfileTechSkillResource, ApplicantProfile>();
        CreateMap<SaveUserProfileTechSkillResource, ApplicantProfile>();
        
        CreateMap<UpdatedUserProfileEducation, ApplicantProfileEducation>();
        CreateMap<SaveApplicantProfileEducationResource, ApplicantProfileEducation>();

        CreateMap<UpdateCareerResource, Career>();
        CreateMap<SaveCareerResource, Career>();

        //CreateMap<>();
    }
}