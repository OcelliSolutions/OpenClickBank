namespace Ocelli.OpenClickBank;

public class NotificationCustomer
{
    public NotificationShippingContact Shipping { get; set; } = null!;


    public NotificationBillingContact Billing { get; set; } = null!;
}