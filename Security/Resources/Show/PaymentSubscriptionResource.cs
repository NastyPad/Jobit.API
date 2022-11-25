using Jobit.API.Security.Resources.Bases;

namespace Jobit.API.Security.Resources.Show;

public class PaymentSubscriptionResource
{
    public long PaymentSubscriptionId { get; set; }
    public String? CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Ccv { get; set; }
    public UserSimpleBaseResource? User { get; set; }
}