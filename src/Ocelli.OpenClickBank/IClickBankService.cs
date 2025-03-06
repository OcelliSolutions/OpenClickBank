namespace Ocelli.OpenClickBank;

public interface IClickBankService
{
    IAnalyticsClient Analytics { get; }
    IDebugClient Debugs { get; }
    IImagesClient Images { get; }
    INotificationService Notifications { get; }
    IOrdersClient Orders { get; }
    IOrders2Client Orders2 { get; }
    IProductsClient Products { get; }
    IQuickstatsClient Quickstats { get; }
    IShippingClient Shipping { get; }
    IShipping2Client Shipping2 { get; }
    IShipping3Client Shipping3 { get; }
    ITicketsClient Tickets { get; }
}