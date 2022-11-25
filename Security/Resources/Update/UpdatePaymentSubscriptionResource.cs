namespace Jobit.API.Security.Resources.Update;

public class UpdatePaymentSubscriptionResource
{
    public String? CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Ccv { get; set; }
}