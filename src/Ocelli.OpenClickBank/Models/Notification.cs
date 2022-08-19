using System.Text.Json.Serialization;

namespace Ocelli.OpenClickBank;

public class Notification
{
    [JsonConverter(typeof(Converters.DateTimeOffsetConverter))]
    public DateTimeOffset? TransactionTime { get; set; }
    
    public string Receipt { get; set; } = null!;

    public NotificationTransactionType TransactionType { get; set; }
    
    public string Vendor { get; set; } = null!;

    public string? Affiliate { get; set; }

    public NotificationRole Role { get; set; }

    public decimal TotalAccountAmount { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; }
    
    public decimal TotalOrderAmount { get; set; }
    
    public decimal TotalTaxAmount { get; set; }
    
    public decimal TotalShippingAmount { get; set; }
    
    public string Currency { get; set; } = null!;

    public string? OrderLanguage { get; set; }
    public IEnumerable<string>? TrackingCodes { get; set; }
    public bool? DeclinedConsent { get; set; }
    
    public IEnumerable<NotificationLineItem> LineItems { get; set; } = null!;

    public NotificationCustomer Customer { get; set; } = null!;

    public NotificationUpsell? Upsell { get; set; }

    [Obsolete(
        "The Pytch feature has been deprecated, but the parameters are retained for backwards compatibility purposes")]
    public NotificationPytch? Hopfeed { get; set; }

    public decimal Version { get; set; }
    
    public int AttemptCount { get; set; }
    public NotificationVendorVariables? VendorVariables { get; set; }
}
