namespace Ocelli.OpenClickBank.Builder.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class TicketList
{
    public TicketList() => TicketData = new HashSet<TicketData>();
    public IEnumerable<TicketData> TicketData { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
