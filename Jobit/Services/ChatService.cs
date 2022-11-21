using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IRecruiterRepository _recruiterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChatService(IChatRepository chatRepository, IApplicantRepository applicantRepository,IRecruiterRepository recruiterRepository,IUnitOfWork unitOfWork)
    {
        _applicantRepository = applicantRepository;
        _recruiterRepository=recruiterRepository;
        _chatRepository = chatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Chat>> ListChatsAsync()
    {
        var chats = await _chatRepository.ListChatsAsync();
        chats.ToList().ForEach(
             chat => {
                chat.Recruiter =  _recruiterRepository.FindRecruiterByRecruiterIdAsync(chat.RecruiterId).Result;
                chat.Applicant =  _recruiterRepository.FindApplicantByApplicantIdAsync(chat.ApplicantId).Result;
             } 
             );
       
        return chats.AsEnumerable();
    }

    public async Task<ChatResponse> FindByChatIdAsync(int chatId)
    {
        var existingChat = await _chatRepository.FindByChatIdAsync(chatId);
        if (existingChat == null)
            return new ChatResponse("Chat does not exist.");
        try
        {
            return new ChatResponse(existingChat);
        }
        catch (Exception exception)
        {
            return new ChatResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<ChatResponse> AddChatAsync(Chat newChat)
    {
        try
        {
            await _chatRepository.AddChatAsync(newChat);
            await _unitOfWork.CompleteAsync();
            return new ChatResponse(newChat);
        }
        catch (Exception exception)
        {
            return new ChatResponse($"An error has occurred while trying to add new chat: {exception.Message}");
        }
    }

    public async Task<ChatResponse> UpdateChatAsync(long chatId, Chat updateChat)
    {
        var existingChat = await _chatRepository.FindByChatIdAsync(chatId);
        if (existingChat == null)
            return new ChatResponse("Chat does not exist.");
        
        existingChat.ApplicantId = updateChat.ApplicantId;
        existingChat.RecruiterId = updateChat.RecruiterId;
        
        try
        {
            _chatRepository.UpdateChatAsync(existingChat);
            await _unitOfWork.CompleteAsync();
            return new ChatResponse(updateChat);
        }
        catch (Exception exception)
        {
            return new ChatResponse($"An error has occurred while trying to update this chat: {exception.Message}");
        }
    }

    public async Task<ChatResponse> DeleteChatAsync(long chatId)
    {
        var existingChat = await _chatRepository.FindByChatIdAsync(chatId);
        if (existingChat == null)
            return new ChatResponse("Chat does not exist.");
        try
        {
            _chatRepository.DeleteChatAsync(existingChat);
            await _unitOfWork.CompleteAsync();
            return new ChatResponse(existingChat);
        }
        catch (Exception exception)
        {
            return new ChatResponse($"An error has occurred while trying to delete this chat: {exception.Message}");
        }
    }
}