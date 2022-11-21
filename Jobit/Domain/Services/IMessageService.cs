using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IMessageService
{
    Task<IEnumerable<Message>> ListMessagesAsync();
    Task<MessageResponse> FindByMessageIdAsync(int messageId);
    Task<MessageResponse> AddMessageAsync(Message newMessage);
    Task<MessageResponse> UpdateMessageAsync(long messageId, Message updateMessage);
    Task<MessageResponse> DeleteMessageAsync(long messageId);
}