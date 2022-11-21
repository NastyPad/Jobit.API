using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> ListMessageAsync();
    Task<Message> FindMessageByMessageIdAsync(long messageId);
    Task AddMessageAsync(Message message);
    void UpdateMessage(Message message);
    void DeleteMessage(Message message);
}