using System.Text.Json.Serialization;
using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class OrderData
{
    public DateTimeOffset? TransactionTime { get; set; }
    public string? Receipt { get; set; }
    public string? TrackingId { get; set; }
    [JsonPropertyName("paytmentMethod")] 
    public PaymentMethod PaymentMethod { get; set; }
    public TransactionType? TransactionType { get; set; }
    public decimal? TotalOrderAmount { get; set; }
    public decimal? TotalShippingAmount { get; set; }
    public decimal? TotalTaxAmount { get; set; }
    public string? Vendor { get; set; }
    public string? Affiliate { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public Currency? Currency { get; set; }
    public bool DeclinedConsent { get; set; }
    public string? Email { get; set; }
    public string? PostalCode { get; set; }
    public ContactField[]? CustomerContactInfo { get; set; }
    public OrderRole? Role { get; set; }
    public string? FullName { get; set; }
    public RefundableState? CustomerRefundableState { get; set; }
    public VendorVariableElementArray? VendorVariables { get; set; }
    public LineItemData[]? LineItemData { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
