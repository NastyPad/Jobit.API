using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IChatService
{
    Task<IEnumerable<Chat>> ListChatsAsync();
    Task<ChatResponse> FindByChatIdAsync(int chatId);
    Task<ChatResponse> AddChatAsync(Chat newChat);
    Task<ChatResponse> UpdateChatAsync(long chatId, Chat updateChat);
    Task<ChatResponse> DeleteChatAsync(long chatId);
}