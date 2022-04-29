namespace OpenClickBank.Builder.Models;

public class LineItemData
{
    public string ItemNo { get; set; } = null!;
    public string? ProductTitle { get; set; }
    public bool Recurring { get; set; }
    public bool Shippable { get; set; }
    public decimal? CustomerAmount { get; set; }
    public decimal? AccountAmount { get; set; }
    public int? Quantity { get; set; }
    public string? LineItemType { get; set; }
    public decimal? RebillAmount { get; set; }
    public int? ProcessedPayments { get; set; }
    public int? FuturePayments { get; set; }
    public DateTimeOffset? NextPaymentDate { get; set; }
    public string? Status { get; set; }
    public string? Role { get; set; }
}