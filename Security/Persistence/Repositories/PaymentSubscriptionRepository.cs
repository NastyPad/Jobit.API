using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Security.Persistence;

public class PaymentSubscriptionRepository : BaseRepository, IPaymentSubscriptionRepository
{
    public PaymentSubscriptionRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<PaymentSubscription>> ListAllPaymentSubscriptionAsync()
    {
        return await _databaseContext.PaymentSubscriptions.ToListAsync();
    }

    public async Task<PaymentSubscription> FindPaymentSubscriptionAsync(long paymentSubscriptionId)
    {
        return await _databaseContext.PaymentSubscriptions.FindAsync(paymentSubscriptionId);
    }

    public async Task AddPaymentSubscriptionAsync(PaymentSubscription newPaymentSubscription)
    {
        await _databaseContext.AddAsync(newPaymentSubscription);
    }

    public void UpdatePaymentSubscription(PaymentSubscription updatedPaymentSubscription)
    {
        _databaseContext.Update(updatedPaymentSubscription);
    }

    public void DeletePaymentSubscription(PaymentSubscription deletePaymentSubscription)
    {
        _databaseContext.Remove(deletePaymentSubscription);
    }
}