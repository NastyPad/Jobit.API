using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Creation, read, update Chats")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly IMapper _mapper;

    public ChatController(IChatService chatService, IMapper mapper)
    {
        _chatService = chatService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ChatResource>> GetAllChatsAsync()
    {
        var chats = await _chatService.ListChatsAsync();
        var resources = _mapper.Map<IEnumerable<Job>, IEnumerable<ChatResource>>(chats);
        return resources;
    }

    [HttpPost]
    [SwaggerResponse(200, "The operation was successful", typeof(ChatResource))]
    [SwaggerResponse(500, "The chat data is not valid")]
    public async Task<IActionResult> PostChatAsync([FromBody, SwaggerRequestBody("Chat")] SaveChatResource newChat)
    {
        var newChatMapped = _mapper.Map<SaveChatResource, Chat>(newChat);
        var result = await _chatService.AddChatAsync(newChatMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var newChatResponse = _mapper.Map<Chat, ChatResource>(result.Resource);
        return Ok(newChatResponse);
    }
    
    [HttpPut("{chatId}")]
    public async Task<IActionResult> PutChatAsync(long chatId, [FromBody, SwaggerRequestBody("Updated Chat")] UpdateChatResource updateChat)
    {
        var updatedChatMapped = _mapper.Map<UpdateChatResource, Chat>(updateChat);
        var result = await _chatService.UpdateChatAsync(chatId, updatedChatMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var updatedChatResponse = _mapper.Map<Chat, ChatResource>(result.Resource);
        return Ok(updatedChatResponse);
    }
    
    [HttpDelete("{chatId}")]
    public async Task<IActionResult> DeleteChatAsync(long chatId)
    {
        var result = await _chatService.DeleteChatAsync(chatId);
        if (!result.Success)
            return BadRequest(result.Message);
        var deletedChatResponse = _mapper.Map<Chat, ChatResource>(result.Resource);
        return Ok(deletedChatResponse);
    }
}