using OpenClickBank.Builder.Data;
using System.Text.Json.Serialization;

namespace OpenClickBank.Builder.Models;

public class OrderData
{
    public DateTimeOffset? TransactionTime { get; set; }
    public string? Receipt { get; set; }
    public string? TrackingId { get; set; }
    [JsonPropertyName("paytmentMethod")] 
    public string? PaymentMethod { get; set; }
    public string? TransactionType { get; set; }
    public decimal? TotalOrderAmount { get; set; }
    public decimal? TotalShippingAmount { get; set; }
    public decimal? TotalTaxAmount { get; set; }
    public string? Vendor { get; set; }
    public object? Affiliate { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? Currency { get; set; }
    public bool? DeclinedConsent { get; set; }
    public string? Email { get; set; }
    public string? PostalCode { get; set; }
    public ContactField[]? CustomerContactInfo { get; set; }
    public string? Role { get; set; }
    public string? FullName { get; set; }
    public RefundableState? CustomerRefundableState { get; set; }
    public VendorVariables? VendorVariables { get; set; }
    public LineItemData? LineItemData { get; set; }
}