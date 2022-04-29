namespace OpenClickBank.Builder.Models;

public class OrderShipLineItemData
{
    public string? ItemNo { get; set; }
    public string? ProductTitle { get; set; }
    public decimal? CustomerAmount { get; set; }
    public decimal? AccountAmount { get; set; }
    public int? Quantity { get; set; }
    public string? ShippingMethod { get; set; }
    public bool? IsRefundPending { get; set; }
    public bool? HasBeenRefunded { get; set; }
    public bool? HasBeenChargebacked { get; set; }
}