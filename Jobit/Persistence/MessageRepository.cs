using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class MessageRepository : BaseRepository, IMessageRepository
{
    public MessageRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Message>> ListMessageAsync()
    {
        return await _databaseContext.Messages.ToListAsync();
    }

    public async Task<Message> FindMessageByMessageIdAsync(long messagesId)
    {
        return await _databaseContext.Messages.FindAsync(messagesId);
    }

    public async Task AddMessageAsync(Message messages)
    {
        await _databaseContext.Messages.AddAsync(messages);
    }

    public void UpdateMessage(Message messages)
    {
        _databaseContext.Messages.Update(messages);
    }

    public void DeleteMessage(Message messages)
    {
        _databaseContext.Messages.Remove(messages);
    }
}