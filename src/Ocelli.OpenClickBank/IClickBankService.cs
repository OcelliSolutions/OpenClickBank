namespace Ocelli.OpenClickBank;

public interface IClickBankService
{
    OpenClickBankConfig OpenClickBankConfig { get; set; }
    IAnalyticsClient Analytics { get; }
    IDebugClient Debugs { get; }
    IImageClient Images { get; }
    INotificationService Notifications { get; }
    IOrdersClient Orders { get; }
    IProductClient Products { get; }
    IQuickstatsClient Quickstats { get; }
    IShippingClient Shipping { get; }
    ITicketClient Tickets { get; }
}