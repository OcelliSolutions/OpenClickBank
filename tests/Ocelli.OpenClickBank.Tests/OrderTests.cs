using System.Diagnostics;

namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("OrderTests")]
public class OrderTests : IClassFixture<SharedFixture>
{
    private string Receipt => Fixture.ApiKey.OpenClickBankConfig.Receipt ?? throw new ArgumentNullException(nameof(Fixture.ApiKey.OpenClickBankConfig.Receipt), "`receipt` must be defined in `api_keys.json`");
    private SharedFixture Fixture { get; }
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly OrderMockClient _badRequestMockClient;
    private readonly OrderMockClient _okEmptyMockClient;
    private readonly OrderMockClient _okInvalidJsonMockClient;

    public OrderTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new OrderMockClient(sharedFixture.BadRequestMockHttpClient);
        _okEmptyMockClient = new OrderMockClient(sharedFixture.OkEmptyMockHttpClient);
        _okInvalidJsonMockClient = new OrderMockClient(sharedFixture.OkInvalidJsonMockHttpClient);
    }

    #region Create

    //There are no endpoints for creating orders.

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetOrdersAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var results = new List<OrderData>();
        var hasMoreData = false;
        var page = 1;
        do
        {
            var orders =
                await Fixture.ApiKey.ClickBankService.Orders.GetOrdersAsync(startDate: DateTimeOffset.Now.AddDays(-1),
                    endDate: DateTimeOffset.Now, page: page);
            _additionalPropertiesHelper.CheckAdditionalProperties(orders, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
            Debug.Assert(orders?.OrderData != null, "orders.OrderData != null");
            Assert.NotEmpty(orders.OrderData);
            foreach (var order in orders.OrderData)
                _additionalPropertiesHelper.CheckAdditionalProperties(order,
                    Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
            if (orders.OrderData != null) results.AddRange(orders.OrderData);
            hasMoreData = orders.HasMoreData;
            page++;
        } while (hasMoreData);
        _testOutputHelper.WriteLine($@"Orders Tested: {results.Count}");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetOrderCountAsync_ReturnNumber_ShouldPass()
    {
        var orders =
            await Fixture.ApiKey.ClickBankService.Orders.GetOrderCountAsync(startDate: DateTimeOffset.Now.AddDays(-10),
                endDate: DateTimeOffset.Now);
        Assert.NotEqual(0, orders);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetOrderAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var response = await Fixture.ApiKey.ClickBankService.Orders.GetOrderAsync(this.Receipt, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetOrderUpsellsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var response = await Fixture.ApiKey.ClickBankService.Orders.GetOrderUpsellsAsync(this.Receipt, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    #endregion Read

    #region Update

    [SkippableFact]
    [TestPriority(20)]
    public async Task ChangeOrderAddressAsync_CanCall() =>
        await Fixture.ApiKey.ClickBankService.Orders.ChangeOrderAddressAsync(receipt: this.Receipt,
            address1: "123 Test St.", city: "Middle", county:"Nowhere", countryCode: "US", postalCode: "80030", province: "CO",
            cancellationToken: CancellationToken.None);

    #endregion Update

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class OrderMockClient : Orders2Client, IMockTests
{
    public OrderMockClient(HttpClient httpClient) : base(httpClient)
    {
        BaseUrl = "https://localhost";
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrdersAsync("", 0, "", "", "", "", RoleAccount.AFFILIATE, DateTimeOffset.Now, DateTimeOffset.Now, "", OrderType.BILL, "", 1, CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrderAsync("", "", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrderUpsellsAsync("", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ChangeOrderAddressAsync("","","","","", "", "", "", "", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ChangeOrderDateAsync("", DateTimeOffset.Now, "",  cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ChangeOrderProductAsync("", "", "", "", false, DateTimeOffset.Now, cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ExtendOrderAsync("", 1, "", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await PauseOrderAsync("", DateTimeOffset.Now, "", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ReinstateOrderAsync("", "", cancellationToken: CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrdersAsync(cancellationToken: CancellationToken.None));
    }
}
