using Jobit.API.Security.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services.Communication.Responses;

public class PaymentSubscriptionResponse : BaseResponse<PaymentSubscription>
{
    public PaymentSubscriptionResponse(PaymentSubscription resource) : base(resource)
    {
    }

    public PaymentSubscriptionResponse(string message) : base(message)
    {
    }
}