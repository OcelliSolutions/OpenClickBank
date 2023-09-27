namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class PartialRefundData
{
    public decimal UsdAmount { get; set; }
    public decimal CustomerAmount { get; set; }
    public string CustomerCurrency { get; set; } = null!;
    public decimal ProductAmount { get; set; }
    public string ProductCurrency { get; set; } = null!;
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
