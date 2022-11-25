using AutoMapper;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Resources.Generate;
using Jobit.API.Security.Resources.Show;
using Jobit.API.Security.Resources.Update;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Security.Controllers.Payment;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("PaymentSubscription")]
public class PaymentSubscriptionController : ControllerBase
{
    private readonly IPaymentSubscriptionService _paymentSubscriptionService;
    private readonly IMapper _mapper;

    public PaymentSubscriptionController(IPaymentSubscriptionService paymentSubscriptionService, IMapper mapper)
    {
        _paymentSubscriptionService = paymentSubscriptionService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PaymentSubscriptionResource>> ListAllPaymentSubscriptions()
    {
        var paymentSubscriptions = await _paymentSubscriptionService.ListAllPaymentSubscriptionAsync();
        var mappedPaymentSubscriptions = _mapper.Map<IEnumerable<PaymentSubscription>, IEnumerable<PaymentSubscriptionResource>>(paymentSubscriptions);
        return mappedPaymentSubscriptions;
    }

    [HttpGet("{subscriptionId}")]
    public async Task<IActionResult> GetPaymentSubscriptionBySubscriptionId(long subscriptionId)
    {
        var result =
            await _paymentSubscriptionService.FindPaymentSubscriptionByPaymentSubscriptionIdAsync(subscriptionId);
        if (!result.Success)
            return BadRequest(result.Message);
        var subscriptionResponse = _mapper.Map<PaymentSubscription, PaymentSubscriptionResource>(result.Resource);
        return Ok(subscriptionResponse);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostPaymentSubscriptionBySubscriptionId([FromBody, SwaggerRequestBody("")] GeneratePaymentSubscription newPaymentSubscription)
    {
        var mappedPaymentSubscription = _mapper.Map<GeneratePaymentSubscription, PaymentSubscription>(newPaymentSubscription);
        var result = await _paymentSubscriptionService.AddPaymentSubscriptionAsync(mappedPaymentSubscription);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(new { message = "Successfully added."});
    }
    
    [HttpPut("{paymentSubscriptionId}")]
    public async Task<IActionResult> PutPaymentSubscriptionBySubscriptionId(long paymentSubscriptionId, [FromBody, SwaggerRequestBody("")] UpdatePaymentSubscriptionResource updatedPaymentSubscription)
    {
        var mappedPaymentSubscription = _mapper.Map<UpdatePaymentSubscriptionResource, PaymentSubscription>(updatedPaymentSubscription);
        var result = await _paymentSubscriptionService.UpdatePaymentSubscriptionAsync(paymentSubscriptionId, mappedPaymentSubscription);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(new { message = "Successfully updated."});
    }
    [HttpPut("{paymentSubscriptionId}")]
    public async Task<IActionResult> PutPaymentSubscriptionBySubscriptionId(long paymentSubscriptionId)
    {
        var result = await _paymentSubscriptionService.DeletePaymentSubscriptionAsync(paymentSubscriptionId);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(new { message = "Successfully deleted."});
    }
}