using System.Diagnostics;

namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("OrderTests")]
public class OrderTests : IClassFixture<SharedFixture>
{
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
        bool hasMoreData;
        var page = 1;
        do
        {
            var orders =
                await Fixture.ApiKey.ClickBankService.Orders.GetOrdersAsync(startDate: DateOnly.FromDateTime(DateTime.Now).AddDays(-30),
                    endDate: DateOnly.FromDateTime(DateTime.Now), page: page);
            _additionalPropertiesHelper.CheckAdditionalProperties(orders, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
            Debug.Assert(orders.Result?.OrderData != null, "orders.OrderData != null");
            Assert.NotEmpty(orders.Result.OrderData);
            foreach (var order in orders.Result.OrderData)
                _additionalPropertiesHelper.CheckAdditionalProperties(order,
                    Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
            if (orders.Result.OrderData != null) results.AddRange(orders.Result.OrderData);
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
            await Fixture.ApiKey.ClickBankService.Orders.GetOrderCountAsync(startDate: DateOnly.FromDateTime(DateTime.Now).AddDays(-30),
                endDate: DateOnly.FromDateTime(DateTime.Now));
        Assert.NotEqual(0, orders);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetOrderAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var response = await Fixture.ApiKey.ClickBankService.Orders.GetOrderAsync(Fixture.Receipt, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetOrderUpsellsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var response = await Fixture.ApiKey.ClickBankService.Orders.GetOrderUpsellsAsync(Fixture.Receipt, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    #endregion Read

    #region Update

    [SkippableFact]
    [TestPriority(20)]
    public async Task ChangeOrderAddressAsync_CanCall() =>
        await Fixture.ApiKey.ClickBankService.Orders.ChangeOrderAddressAsync(receipt: Fixture.Receipt,
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

internal class OrderMockClient : OrdersClient, IMockTests
{
    public OrderMockClient(HttpClient httpClient) : base(httpClient) => BaseUrl = "https://localhost";

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrdersAsync("", 0, "", "", "", "", RoleAccount.AFFILIATE, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now), "", TransactionType.BILL, "", 1, CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrderAsync("", "", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrderUpsellsAsync("", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ChangeOrderAddressAsync("","","","","", "", "", "", "", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ChangeOrderDateAsync("", DateOnly.FromDateTime(DateTime.Now), "",  cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ChangeOrderProductAsync("", "", "", "", false, DateOnly.FromDateTime(DateTime.Now), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ExtendOrderAsync("", 1, "", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await PauseOrderAsync("", DateOnly.FromDateTime(DateTime.Now), "", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ReinstateOrderAsync("", "", cancellationToken: CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrdersAsync(cancellationToken: CancellationToken.None));
    }
}
