namespace Ocelli.OpenClickBank;

public class NotificationLineItem
{
    public string? ItemNo { get; set; }
    public string? ProductTitle { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal ProductDiscount { get; set; }
    public decimal JvPayout { get; set; }
    public decimal AffiliatePayout { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal ShippingAmount { get; set; }
    public bool ShippingLiable { get; set; }
    public bool Shippable { get; set; }
    public bool Recurring { get; set; }
    public decimal AccountAmount { get; set; }
    public int Quantity { get; set; }
    public string? DownloadUrl { get; set; }
    public string? LineItemType { get; set; }
}