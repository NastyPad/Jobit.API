using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Security.Domain.Services.Communication.Responses;
using Jobit.API.Security.Domain.Services.Communication.Update;
using Jobit.API.Security.Resources.Generate;

namespace Jobit.API.Security.Domain.Services;

public interface IMessageService
{
    Task<IEnumerable<Message>> ListAllMessagesByChatIdAsync(long recruiterId, long applicantId);
    Task<MessageResponse> FindMessageByMessageIdAsync(long messageId);
    Task<MessageResponse> SentMessageAsync(SentMessage newMessage);
    Task<MessageResponse> EditMessageAsync(long messageId, EditMessage toEditMessage);
    Task<MessageResponse> DeleteMessageAsync(long messageId);
}