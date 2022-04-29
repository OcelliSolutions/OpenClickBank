namespace OpenClickBank;

public interface IClickBankService
{
    OpenClickBankConfig OpenClickBankConfig { get; set; }
    IAnalyticsClient Analytics { get; }
    IDebugClient Debugs { get; }
    IImageClient Images { get; }
    IOrders2Client Orders { get; }
    IProductClient Products { get; }
    IQuickstatsClient Quickstats { get; }
    IShipping2Client Shipping { get; }
    ITicketClient Tickets { get; }
}