using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class ChatRepository : BaseRepository, IChatRepository
{
    public ChatRepository(AppDatabaseContext databaseContext) : base(databaseContext) {}

    public async Task<IEnumerable<Chat>> ListChatsAsync()
    {
        return await _databaseContext.Chats.ToListAsync();
    }

    public async Task AddChatAsync(Chat newChat)
    {
        await _databaseContext.Chats.AddAsync(newChat);
    }

    public void UpdateChatAsync(Chat updateChat)
    {
        _databaseContext.Chats.Update(updateChat);
    }

    public void DeleteChatAsync(Chat deleteChat)
    {
        _databaseContext.Chats.Remove(deleteChat);
    }

    public async Task<Chat> FindByChatIdAsync(long chatId)
    {
        return await _databaseContext.Chats.FindAsync(chatId);
    }
}