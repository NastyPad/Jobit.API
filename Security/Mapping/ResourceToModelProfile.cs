using AutoMapper;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Security.Domain.Services.Communication;
using Jobit.API.Security.Domain.Services.Communication.Responses;
using Jobit.API.Security.Domain.Services.Communication.Update;
using Jobit.API.Security.Resources;
using Jobit.API.Security.Resources.Generate;

namespace Jobit.API.Security.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<UserResource, User>();
        CreateMap<CompanyResource, Company>();
        CreateMap<RegisterUserRequest, User>();
        
        //Applicant
        CreateMap<RegisterApplicantRequest, Applicant>();
        CreateMap<UpdateApplicantRequest, Applicant>();
        
        //Recruiter 
        CreateMap<RegisterRecruiterRequest, Recruiter>();
        CreateMap<UpdateRecruiterRequest, Recruiter>();

        //Message
        CreateMap<EditMessage, Message>();
        CreateMap<SentMessage, Message>();
        
        //Chat
        CreateMap<GenerateChat, Chat>();
    }
}