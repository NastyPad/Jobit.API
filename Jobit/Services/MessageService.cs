using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public MessageService(IMessageRepository messageRepository, IChatRepository chatRepository , IMapper mapper, IUnitOfWork unitOfWork )
    {
        _messageRepository = messageRepository;
        _chatRepository = chatRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Message>> ListMessagesAsync()
    {
        var messages = await _messagesRepository.ListMessageAsync();
        messages.ToList().ForEach(message =>
        {
            message.Chat = _chatRepository.FindByChatIdAsync(message.ChatId).Result;
        });
        return messages.AsEnumerable();
    }

    public async Task<MessageResponse> FindByMessageIdAsync(long messageId)
    {
        var existingMessage = await _messageRepository.FindMessageByMessageIdAsync(messageId);
        if (existingMessage == null)
            return new MessageResponse("Message does not exist.");
        try
        {
            return new MessageResponse(existingMessage);
        }
        catch (Exception exception)
        {
            return new MessageResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<MessageResponse> AddMessageAsync(Message message)
    {
        try
        {
            await _messageRepository.AddMessageAsync(message);
            await _unitOfWork.CompleteAsync();
            return new MessageResponse(message);
        }
        catch (Exception exception)
        {
            return new MessageResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<MessageResponse> UpdateMessageAsync(long messageId, Message message)
    {
        var existingMessage = await _messageRepository.FindMessageByMessageIdAsync(messageId);
        if (existingMessage == null)
            return new MessageResponse("Message request does not exist.");
        
        existingMessage.WhoSend  = message.WhoSend ;
        existingMessage.Content  = message.Content ;
        existingMessage.ChatId = message.ChatId;
        
        try
        {
            _messageRepository.UpdateMessage(message);
            await _unitOfWork.CompleteAsync();
            return new MessageResponse(message);
        }
        catch (Exception exception)
        {
            return new MessageResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<MessageResponse> DeleteMessageAsync(long messageId)
    {
        var existingMessage = await _messageRepository.FindMessageByMessageIdAsync(messageId);
        if (existingMessage == null)
            return new MessageResponse("Message does not exist.");

        try
        {
            _messageRepository.DeleteMessage(existingMessage);
            await _unitOfWork.CompleteAsync();
            return new MessageResponse(existingMessage);
        }
        catch (Exception exception)
        {
            return new MessageResponse($"An error has occurred while trying to delete this message: {exception.Message}");
        }
    }
    
}