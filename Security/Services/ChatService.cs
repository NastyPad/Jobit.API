using AutoMapper;
using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication.Responses;
using Jobit.API.Security.Resources.Generate;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Security.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IRecruiterRepository _recruiterRepository;
    private readonly IMessageRepository _messageRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChatService(IChatRepository chatRepository, IUnitOfWork unitOfWork, IMapper mapper, IApplicantRepository applicantRepository, IRecruiterRepository recruiterRepository, IMessageRepository messageRepository)
    {
        _chatRepository = chatRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _applicantRepository = applicantRepository;
        _recruiterRepository = recruiterRepository;
        _messageRepository = messageRepository;
    }

    public async Task<ChatResponse> FindChatByChatIdAsync(long applicantId, long recruiterId)
    {
        var existingChat = await _chatRepository.FindChatByChatIdAsync(applicantId, recruiterId);
        if (existingChat == null)
            return new ChatResponse("Chat does not exist.");
        existingChat.Applicant = await _applicantRepository.FindApplicantByApplicantIdAsync(applicantId);
        existingChat.Recruiter = await _recruiterRepository.FindRecruiterByRecruiterIdAsync(recruiterId);
        existingChat.Messages = (await _messageRepository.ListAllMessageByChatIdAsync(recruiterId, applicantId)).ToList();
        return new ChatResponse(existingChat);
    }

    public async Task<ChatResponse> GenerateChatAsync(GenerateChat newChat)
    {
        var mappedChat = _mapper.Map<GenerateChat, Chat>(newChat);
        try
        {
            await _chatRepository.GenerateChat(mappedChat);
            await _unitOfWork.CompleteAsync();
            return new ChatResponse(mappedChat);
        }
        catch (Exception exception)
        {
            return new ChatResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<IEnumerable<Chat>> ListChatsByApplicantIdAsync(long applicantId)
    {
        var chats =  await _chatRepository.ListChatsByApplicantIdAsync(applicantId);
        chats.ToList().ForEach(async chat =>
            {
                chat.Applicant = await _applicantRepository.FindApplicantByApplicantIdAsync(chat.ApplicantId);
                chat.Recruiter = await _recruiterRepository.FindRecruiterByRecruiterIdAsync(chat.RecruiterId);
                chat.Messages = (await _messageRepository.ListAllMessageByChatIdAsync(chat.RecruiterId, chat.ApplicantId)).ToList();
            });
        return chats;
    }

    public async Task<IEnumerable<Chat>> ListChatsByRecruiterIdAsync(long recruiterId)
    {
        var chats =  await _chatRepository.ListChatsByRecruiterIdAsync(recruiterId);
        chats.ToList().ForEach(async chat =>
        {
            chat.Applicant = await _applicantRepository.FindApplicantByApplicantIdAsync(chat.ApplicantId);
            chat.Recruiter = await _recruiterRepository.FindRecruiterByRecruiterIdAsync(chat.RecruiterId);
            chat.Messages = (await _messageRepository.ListAllMessageByChatIdAsync(chat.RecruiterId, chat.ApplicantId)).ToList();
        });
        return chats;
    }
}