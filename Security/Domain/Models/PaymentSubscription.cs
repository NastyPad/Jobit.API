namespace Jobit.API.Security.Domain.Models;

public class PaymentSubscription
{
    public long PaymentSubscriptionId { get; set; }
    public String? CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Ccv { get; set; }
    
    //Relations
    public long UserId { get; set; }
    public User? User { get; set; }

    public void SetPaymentSubscription(PaymentSubscription newPaymentSubscription)
    {
        CardNumber = newPaymentSubscription.CardNumber;
        ExpirationDate = newPaymentSubscription.ExpirationDate;
        Ccv = newPaymentSubscription.Ccv;
    }
}