namespace Ocelli.OpenClickBank.Builder.Models;

public class ShippingList
{
    public ShippingList() => OrderShipData = new HashSet<OrderShipData>();
    public IEnumerable<OrderShipData> OrderShipData { get; set; }
}
