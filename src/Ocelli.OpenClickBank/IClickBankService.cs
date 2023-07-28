namespace Ocelli.OpenClickBank;

public interface IClickBankService
{
    OpenClickBankConfig OpenClickBankConfig { get; set; }
    IAnalyticsClient Analytics { get; }
    IDebugClient Debugs { get; }
    IImagesClient Images { get; }
    INotificationService Notifications { get; }
    IOrders2Client Orders { get; }
    IProductsClient Products { get; }
    IQuickstatsClient Quickstats { get; }
    IShipping3Client Shipping { get; }
    ITicketsClient Tickets { get; }
}