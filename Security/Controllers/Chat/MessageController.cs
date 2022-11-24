using AutoMapper;
using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication.Update;
using Jobit.API.Security.Resources;
using Jobit.API.Security.Resources.Generate;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Security.Controllers.Chat;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag(("Chats"))]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public MessageController(IMessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }

    [HttpGet("{recruiterId}/{applicantId}")]
    public async Task<IEnumerable<MessageResource>> GetAllMessagesByChatId(long recruiterId, long applicantId)
    {
        var messages = await _messageService.ListAllMessagesByChatIdAsync(recruiterId, applicantId);
        var mappedMessages = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
        return mappedMessages;
    }

    [HttpGet("{messageId}")]
    public async Task<IActionResult> GetMessageByMessageId(long messageId)
    {
        var result = await _messageService.FindMessageByMessageIdAsync(messageId);
        if (!result.Success)
            return BadRequest(result.Message);
        var messageResponse = _mapper.Map<Message, MessageResource>(result.Resource);
        return Ok(messageResponse);
    }

    [HttpPost]
    public async Task<IActionResult> SentMessage(
        [FromBody, SwaggerRequestBody("Message to sent")] SentMessage sentMessage)
    {
        var result = await _messageService.SentMessageAsync(sentMessage);
        if (!result.Success)
            return BadRequest(result.Message);
        var messageResponse = _mapper.Map<Message, MessageResource>(result.Resource);
        return Ok(messageResponse);
    }

    [HttpPut("{messageId}")]
    public async Task<IActionResult> EditMessage(long messageId,
        [FromBody, SwaggerRequestBody("Message to edit")] EditMessage editMessage)
    {
        var result = await _messageService.EditMessageAsync(messageId, editMessage);
        if (!result.Success)
            return BadRequest(result.Message);
        var messageResponse = _mapper.Map<Message, MessageResource>(result.Resource);
        return Ok(messageResponse);
    }

    [HttpDelete("{messageId}")]
    public async Task<IActionResult> DeleteMessage(long messageId)
    {
        var result = await _messageService.DeleteMessageAsync(messageId);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(new { message = "Successfully deleted." });
    }
}