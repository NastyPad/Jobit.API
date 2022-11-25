using AutoMapper;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication.Responses;
using Jobit.API.Security.Resources;
using Jobit.API.Security.Resources.Generate;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Security.Controllers.Chat;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag(("Chats"))]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly IMapper _mapper;

    public ChatController(IChatService chatService, IMapper mapper)
    {
        _chatService = chatService;
        _mapper = mapper;
    }

    [HttpGet("{recruiterId}/{applicantId}")]
    public async Task<IActionResult> GetChatByChatId(long recruiterId, long applicantId)
    {
        var result = await _chatService.FindChatByChatIdAsync(applicantId, recruiterId);
        if (!result.Success)
            return BadRequest(result.Message);
        var chatResponse = _mapper.Map<Domain.Models.Chat.Chat, ChatResource>(result.Resource);
        return Ok(chatResponse);
    }

    [HttpPost]
    public async Task<IActionResult> GenerateChat([FromBody, SwaggerRequestBody("Generate chat")] GenerateChat generateChat)
    {
        var result = await _chatService.GenerateChatAsync(generateChat);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(new { message = "Chat created"});
    }
    
    [HttpGet("recruiter/{recruiterId}")]
    public async Task<IEnumerable<ChatResource>> ListChatsByRecruiterId(long recruiterId)
    {
        var chats = await _chatService.ListChatsByApplicantIdAsync(recruiterId);
        var mappedChats = _mapper.Map<IEnumerable<Domain.Models.Chat.Chat>, IEnumerable<ChatResource>>(chats);
        return mappedChats;
    }
    
    [HttpGet("applicant/{applicantId}")]
    public async Task<IEnumerable<ChatResource>> ListChatsByApplicantId(long applicantId)
    {
        var chats = await _chatService.ListChatsByApplicantIdAsync(applicantId);
        var mappedChats = _mapper.Map<IEnumerable<Domain.Models.Chat.Chat>, IEnumerable<ChatResource>>(chats);
        return mappedChats;
    }
}
