using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Resources;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Security.Resources;
using Jobit.API.Security.Resources.Chat;

namespace Jobit.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
        CreateMap<Company, CompanyResource>();
        CreateMap<Applicant, ApplicantResource>();
        CreateMap<Recruiter, RecruiterResource>();
        CreateMap<Recruiter, RecruiterPostJobResource>();
        CreateMap<Applicant, ApplicantSimpleResource>();
        CreateMap<Recruiter, RecruiterSimpleResource>();
        CreateMap<Chat, ChatResource>();
        CreateMap<Message, MessageResource>();
        CreateMap<Notification, NotificationResource>();
    }
    
}