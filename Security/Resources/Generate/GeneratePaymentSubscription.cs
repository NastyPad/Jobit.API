namespace Jobit.API.Security.Resources.Generate;

public class GeneratePaymentSubscription
{
    public String? CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Ccv { get; set; }
}