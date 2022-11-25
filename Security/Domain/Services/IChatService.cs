using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Security.Domain.Services.Communication.Responses;
using Jobit.API.Security.Resources.Generate;

namespace Jobit.API.Security.Domain.Services;

public interface IChatService
{
    Task<ChatResponse> FindChatByChatIdAsync(long applicantId, long recruiterId);
    Task<ChatResponse> GenerateChatAsync(GenerateChat newChat);
    Task<IEnumerable<Chat>> ListChatsByApplicantIdAsync(long applicantId);
    Task<IEnumerable<Chat>> ListChatsByRecruiterIdAsync(long recruiterId);
}