namespace Ocelli.OpenClickBank;

//TODO: Add a method to return a flag if a list has more records (206 response)
internal class ClickBankService(HttpClient httpClient, OpenClickBankConfig config) : IClickBankService
{
    public IAnalyticsClient Analytics => new AnalyticsClient(httpClient);
    public IDebugClient Debugs => new DebugClient(httpClient);
    public IImagesClient Images => new ImagesClient(httpClient);
    public INotificationService Notifications => new NotificationService();
    public IOrdersClient Orders => new OrdersClient(httpClient);
    public IOrders2Client Orders2 => new Orders2Client(httpClient);
    public IProductsClient Products => new ProductsClient(httpClient);
    public IShippingClient Shipping => new ShippingClient(httpClient);
    public IShipping2Client Shipping2 => new Shipping2Client(httpClient);
    public IShipping3Client Shipping3 => new Shipping3Client(httpClient);
    public ITicketsClient Tickets => new TicketsClient(httpClient);
    public IQuickstatsClient Quickstats => new QuickstatsClient(httpClient);
}

public interface IClickBankServiceFactory
{
    IClickBankService Create(OpenClickBankConfig config);
}

internal class ClickBankServiceFactory(IHttpClientFactory httpClientFactory) : IClickBankServiceFactory
{
    public IClickBankService Create(OpenClickBankConfig config)
    {
        var httpClient = httpClientFactory.CreateClient("ClickBankClient");

        // Set the authorization header using the Clerk API Key directly
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", config.ClerkApiKey);

        return new ClickBankService(httpClient, config);
    }
}
