namespace Ocelli.OpenClickBank.Builder.Models;

public class TicketList
{
    public TicketList() => TicketData = new HashSet<TicketData>();
    public IEnumerable<TicketData> TicketData { get; set; }
}