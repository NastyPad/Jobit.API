using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Resources;
using Jobit.API.Jobit.Resources.Show;
using Jobit.API.Security.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<PostJob, PostJobResource>();
        CreateMap<Project, ProjectResource>();
        CreateMap<JobRequest, JobRequestResource>();
        CreateMap<Notification, NotificationResource>();
        CreateMap<TechSkill, TechSkillResource>();
        CreateMap<ApplicantProfile, ApplicantProfileResource>();
        CreateMap<ApplicantProfileTechSkill, ApplicantProfileTechSkillResource>();
        CreateMap<Education, EducationResource>();
        CreateMap<ApplicantProfileEducation, ApplicantProfileEducationResource>();
        CreateMap<Career, CareerResource>();
        CreateMap<RecruiterProfile, RecruiterProfileResource>();
    }
}