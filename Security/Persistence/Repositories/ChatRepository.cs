using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;

namespace Jobit.API.Security.Persistence;

public class ChatRepository : BaseRepository, IChatRepository
{
    public ChatRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<Chat> FindChatByChatIdAsync(long applicantId, long recruiterId)
    {
        return await _databaseContext.Chats.FindAsync(applicantId, recruiterId);
    }

    public async Task GenerateChat(Chat newChat)
    {
        await _databaseContext.Chats.AddAsync(newChat);
    }
}