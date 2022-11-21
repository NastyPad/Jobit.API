using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IChatRepository
{
    Task<IEnumerable<Chat>> ListChatsAsync();
    Task AddChatAsync(Chat newChat);
    void UpdateChatAsync(Chat updatedChat);
    void DeleteChatAsync(Chat deleteChat);
    Task<Chat> FindByChatIdAsync(long ChatId);
    
}