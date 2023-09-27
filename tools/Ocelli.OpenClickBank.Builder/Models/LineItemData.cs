using Ocelli.OpenClickBank.Builder.Data;

namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class LineItemData
{
    public string ItemNo { get; set; } = null!;
    public string? ProductTitle { get; set; }
    public bool Recurring { get; set; }
    public bool Shippable { get; set; }
    public decimal? CustomerAmount { get; set; }
    public decimal? AccountAmount { get; set; }
    public int? Quantity { get; set; }
    public LineItemType? LineItemType { get; set; }
    public decimal? RebillAmount { get; set; }
    public int? ProcessedPayments { get; set; }
    public int? FuturePayments { get; set; }
    public DateTimeOffset? NextPaymentDate { get; set; }
    public LineItemStatus? Status { get; set; }
    public OrderRole? Role { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
