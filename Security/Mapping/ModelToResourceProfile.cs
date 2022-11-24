
using AutoMapper;
using Jobit.API.Jobit.Resources;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Security.Domain.Services.Communication.Responses;
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
        CreateMap<Applicant, ApplicantChatResource>();
        CreateMap<Recruiter, RecruiterChatResource>();
        CreateMap<Chat, ChatResource>();
        CreateMap<Message, MessageResource>();
    }
    
}