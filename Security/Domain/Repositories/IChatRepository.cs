using Jobit.API.Security.Domain.Models.Chat;

namespace Jobit.API.Security.Domain.Repositories;

public interface IChatRepository
{
    Task<Chat> FindChatByChatIdAsync(long applicantId, long recruiterId);
    Task GenerateChat(Chat newChat);
    Task<IEnumerable<Chat>> ListChatsByApplicantIdAsync(long applicantId);
    Task<IEnumerable<Chat>> ListChatsByRecruiterIdAsync(long recruiterId);
}