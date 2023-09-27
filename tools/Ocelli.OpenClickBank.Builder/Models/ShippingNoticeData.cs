namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
