using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Creation, read, update and delete Messages")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public MessageController(IMessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<MessageResource>> GetAllMessagesAsync()
    {
        var messages = await _messageService.ListMessagesAsync();
        var resources = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
        return resources;
    }
    
    [HttpGet("{messageId}")]
    public async Task<MessageResource> GetMessagesAsync(long messageId)
    {
        var result = await _messageService.FindMessageByMessageId(messageId);
        var resource = _mapper.Map<Message, MessageResource>(result.Resource);
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostMessagesAsync([FromBody, SwaggerRequestBody("Message")] SaveJobRequestResource newMessage)
    {
        var newMessageMapped = _mapper.Map<SaveMessageResource, Message>(newMessage);
        var result = await _messageService.AddMessageAsync(newMessageMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var newMessageResult = _mapper.Map<Message, MessageResource>(newMessageMapped);
        return Ok(newMessageResult);

    }
    
    [HttpDelete("{messageId}")]
    public async Task<IActionResult> DeleteMessagesAsync(long messageId)
    {
        var result = await _messageService.DeleteMessageAsync(messageId);
        if (!result.Success)
            return BadRequest(result.Message);
        var deletedMessageResult = _mapper.Map<Message, MessageResource>(result.Resource);
        return Ok(deletedMessageResult);
    }
    
    [HttpPut("{messageId}")]
    public async Task<IActionResult> PutMessagesAsync(long messageId,  [FromBody, SwaggerRequestBody("Message")] UpdateMessageResource updatedMessage)
    {
        var updateMessageMapped = _mapper.Map<UpdateMessageResource, Message>(updatedMessage);
        var result = await _messageService.UpdateMessageAsync(messageId, updateMessageMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var updatedMessageResult = _mapper.Map<Message, MessageResource>(result.Resource);
        return Ok(updatedMessageResult);
    }
}