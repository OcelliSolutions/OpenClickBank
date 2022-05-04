namespace Ocelli.OpenClickBank.Builder.Models;

public class ShippingNoticeData
{
    public DateTimeOffset? ShipDate { get; set; }
    public string? Carrier { get; set; }
    public string? TrackingId { get; set; }
    public string? ShippedTo { get; set; }
    public string? Comments { get; set; }
    public string? Receipt { get; set; }
    public string? ItemNo { get; set; }
}