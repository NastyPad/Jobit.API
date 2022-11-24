using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Security.Persistence.Repositories;

public class MessageRepository : BaseRepository, IMessageRepository
{
    public MessageRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Message>> ListAllMessageByChatIdAsync(long recruiterId, long applicantId)
    {
        return await _databaseContext.Messages.Where(message =>
            message.ApplicantId == applicantId && message.RecruiterId == recruiterId
        ).ToListAsync();
    }

    public async Task<Message> FindMessageByMessageIdAsync(long messageId)
    {
        return await _databaseContext.Messages.FindAsync(messageId);
    }

    public async Task SentMessageAsync(Message newMessage)
    {
        await _databaseContext.Messages.AddAsync(newMessage);
    }

    public void EditMessage(Message toEditMessage)
    {
        _databaseContext.Messages.Update(toEditMessage);
    }

    public void DeleteMessage(Message toDeleteMessage)
    {
        _databaseContext.Messages.Remove(toDeleteMessage);
    }
}