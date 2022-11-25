using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services.Communication.Responses;

namespace Jobit.API.Security.Domain.Services;

public interface IPaymentSubscriptionService
{
    Task<IEnumerable<PaymentSubscription>> ListAllPaymentSubscriptionAsync();
    Task<PaymentSubscriptionResponse> FindPaymentSubscriptionByPaymentSubscriptionIdAsync(long paymentSubscriptionId);
    Task<PaymentSubscriptionResponse> AddPaymentSubscriptionAsync(PaymentSubscription newPaymentSubscription);
    Task<PaymentSubscriptionResponse> UpdatePaymentSubscriptionAsync(long paymentSubscriptionId, PaymentSubscription updatedPaymentSubscription);
    Task<PaymentSubscriptionResponse> DeletePaymentSubscriptionAsync(long paymentSubscriptionId);
}