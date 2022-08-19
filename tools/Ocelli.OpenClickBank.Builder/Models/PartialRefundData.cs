namespace Ocelli.OpenClickBank.Builder.Models;

public class PartialRefundData
{
    public decimal UsdAmount { get; set; }
    public decimal CustomerAmount { get; set; }
    public string CustomerCurrency { get; set; } = null!;
    public decimal ProductAmount { get; set; }
    public string ProductCurrency { get; set; } = null!;
}
