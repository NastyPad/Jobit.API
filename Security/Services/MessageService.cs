using AutoMapper;
using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication.Responses;
using Jobit.API.Security.Domain.Services.Communication.Update;
using Jobit.API.Security.Resources.Generate;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Security.Services;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Message>> ListAllMessagesByChatIdAsync(long recruiterId, long applicantId)
    {
        return await _messageRepository.ListAllMessageByChatIdAsync(recruiterId, applicantId);
    }

    public async Task<MessageResponse> FindMessageByMessageIdAsync(long messageId)
    {
        var existingMessage = await _messageRepository.FindMessageByMessageIdAsync(messageId);
        if (existingMessage == null)
            return new MessageResponse("Message does not exist.");
        return new MessageResponse(existingMessage);
    }

    public async Task<MessageResponse> SentMessageAsync(SentMessage newMessage)
    {
        try
        {
            var mappedMessage = _mapper.Map<SentMessage, Message>(newMessage);
            
            //Set Message to DateTime Now
            mappedMessage.TimeSent = DateTime.Now;
            

            await _messageRepository.SentMessageAsync(mappedMessage);
            await _unitOfWork.CompleteAsync();
            return new MessageResponse(mappedMessage);
        }
        catch (Exception exception)
        {
            return new MessageResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<MessageResponse> EditMessageAsync(long messageId, EditMessage toEditMessage)
    {
        var existingMessage = await _messageRepository.FindMessageByMessageIdAsync(messageId);
        if (existingMessage == null)
            return new MessageResponse("Message does not exist.");

        var mappedEditedMessage = _mapper.Map<EditMessage, Message>(toEditMessage);
        existingMessage.SetMessage(mappedEditedMessage);
        
        try
        {
            _messageRepository.EditMessage(existingMessage);
            await _unitOfWork.CompleteAsync();
            return new MessageResponse(existingMessage);
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
            return new MessageResponse($"An error has occurred: {exception.Message}");
        }
    }
}