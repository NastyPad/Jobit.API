using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Security.Domain.Repositories;

public interface IPaymentSubscriptionRepository
{
    Task<IEnumerable<PaymentSubscription>> ListAllPaymentSubscriptionAsync();
    Task<PaymentSubscription> FindPaymentSubscriptionAsync(long paymentSubscriptionId);
    Task AddPaymentSubscriptionAsync(PaymentSubscription newPaymentSubscription);
    void UpdatePaymentSubscription(PaymentSubscription updatedPaymentSubscription);
    void DeletePaymentSubscription(PaymentSubscription deletePaymentSubscription);
}