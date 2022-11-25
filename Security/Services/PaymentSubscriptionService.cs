using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication.Responses;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Security.Services;

public class PaymentSubscriptionService : IPaymentSubscriptionService
{
    private readonly IPaymentSubscriptionRepository _paymentSubscriptionRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PaymentSubscriptionService(IPaymentSubscriptionRepository paymentSubscriptionRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _paymentSubscriptionRepository = paymentSubscriptionRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<PaymentSubscription>> ListAllPaymentSubscriptionAsync()
    {
        var paymentSubscriptions = await _paymentSubscriptionRepository.ListAllPaymentSubscriptionAsync();
        paymentSubscriptions.ToList().ForEach(
            async paymentSubscription =>
            {
                paymentSubscription.User = await _userRepository.FindUserByUserIdAsync(paymentSubscription.UserId);
            });
        return paymentSubscriptions;
    }

    public async Task<PaymentSubscriptionResponse> FindPaymentSubscriptionByPaymentSubscriptionIdAsync(long paymentSubscriptionId)
    {
        var existingPaymentSubscription = await _paymentSubscriptionRepository.FindPaymentSubscriptionAsync(paymentSubscriptionId);
        if (existingPaymentSubscription == null)
            return new PaymentSubscriptionResponse("Payment subscription does not exist.");
        existingPaymentSubscription.User = await _userRepository.FindUserByUserIdAsync(existingPaymentSubscription.UserId);
        return new PaymentSubscriptionResponse(existingPaymentSubscription);
    }

    public async Task<PaymentSubscriptionResponse> AddPaymentSubscriptionAsync(PaymentSubscription newPaymentSubscription)
    {
        try
        {
            await _paymentSubscriptionRepository.AddPaymentSubscriptionAsync(newPaymentSubscription);
            await _unitOfWork.CompleteAsync();
            return new PaymentSubscriptionResponse(newPaymentSubscription);
        }
        catch (Exception exception)
        {
            return new PaymentSubscriptionResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<PaymentSubscriptionResponse> UpdatePaymentSubscriptionAsync(long paymentSubscriptionId, PaymentSubscription updatedPaymentSubscription)
    {
        var existingPaymentSubscription = await _paymentSubscriptionRepository.FindPaymentSubscriptionAsync(paymentSubscriptionId);
        if (existingPaymentSubscription == null)
            return new PaymentSubscriptionResponse("Payment subscription does not exist.");
        
        existingPaymentSubscription.SetPaymentSubscription(updatedPaymentSubscription);
        
        try
        {
            _paymentSubscriptionRepository.UpdatePaymentSubscription(existingPaymentSubscription);
            await _unitOfWork.CompleteAsync();
            return new PaymentSubscriptionResponse(existingPaymentSubscription);
        }
        catch (Exception exception)
        {
            return new PaymentSubscriptionResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async Task<PaymentSubscriptionResponse> DeletePaymentSubscriptionAsync(long paymentSubscriptionId)
    {
        var existingPaymentSubscription = await _paymentSubscriptionRepository.FindPaymentSubscriptionAsync(paymentSubscriptionId);
        if (existingPaymentSubscription == null)
            return new PaymentSubscriptionResponse("Payment subscription does not exist.");

        try
        {
            _paymentSubscriptionRepository.DeletePaymentSubscription(existingPaymentSubscription);
            await _unitOfWork.CompleteAsync();
            return new PaymentSubscriptionResponse(existingPaymentSubscription);
        }
        catch (Exception exception)
        {
            return new PaymentSubscriptionResponse($"An error has occurred: {exception.Message}");
        }
    }
}