using Jobit.API.Security.Domain.Models.Chat;

namespace Jobit.API.Security.Domain.Repositories;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> ListAllMessageByChatIdAsync(long recruiterId, long applicantId);
    Task<Message> FindMessageByMessageIdAsync(long messageId);
    Task SentMessageAsync(Message newMessage);
    void EditMessage(Message toEditMessage);
    void DeleteMessage(Message toDeleteMessage);
}