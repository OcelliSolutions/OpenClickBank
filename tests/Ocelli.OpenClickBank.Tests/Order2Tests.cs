using System.Diagnostics;
using Xunit.Priority;

namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("OrderTests")]
public class Order2Tests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    : IClassFixture<SharedFixture>
{
    private SharedFixture Fixture { get; } = sharedFixture;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper = new(testOutputHelper);
    private readonly Order2MockClient _badRequestMockClient = new(sharedFixture.BadRequestMockHttpClient);
    private readonly Order2MockClient _okEmptyMockClient = new(sharedFixture.OkEmptyMockHttpClient);
    private readonly Order2MockClient _okInvalidJsonMockClient = new(sharedFixture.OkInvalidJsonMockHttpClient);

    #region Create

    //There are no endpoints for creating orders.

    #endregion Create

    #region Read

    [SkippableFact]
    [Priority(20)]
    public async Task GetOrdersAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var results = new List<OrderData>();
        bool hasMoreData;
        var page = 1;
        do
        {
            var orders =
                await Fixture.ApiKey.ClickBankService.Orders2.GetOrders2Async(startDate: DateOnly.FromDateTime(DateTime.Now).AddDays(-30),
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
        testOutputHelper.WriteLine($@"Orders Tested: {results.Count}");
    }

    [SkippableFact]
    [Priority(20)]
    public async Task GetOrderCountAsync_ReturnNumber_ShouldPass()
    {
        var orders =
            await Fixture.ApiKey.ClickBankService.Orders2.GetOrderCount2Async(startDate: DateOnly.FromDateTime(DateTime.Now).AddDays(-30),
                endDate: DateOnly.FromDateTime(DateTime.Now));
        Assert.NotEqual(0, orders);
    }

    [SkippableFact]
    [Priority(20)]
    public async Task GetOrderAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var response = await Fixture.ApiKey.ClickBankService.Orders2.GetOrder2Async(Fixture.Receipt, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    [SkippableFact]
    [Priority(20)]
    public async Task GetOrderUpsellsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var response = await Fixture.ApiKey.ClickBankService.Orders2.GetOrderUpsells2Async(Fixture.Receipt, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    #endregion Read

    #region Update

    [SkippableFact]
    [Priority(20)]
    public async Task ChangeOrderAddressAsync_CanCall() =>
        await Fixture.ApiKey.ClickBankService.Orders2.ChangeAddressOrder2Async(receipt: Fixture.Receipt,
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

internal class Order2MockClient : Orders2Client, IMockTests
{
    public Order2MockClient(HttpClient httpClient) : base(httpClient) => BaseUrl = "https://localhost";

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrders2Async(DateOnly.FromDateTime(DateTime.Now),
            DateOnly.FromDateTime(DateTime.Now), TransactionType.BILL, "", "", "", "", "", "", RoleAccount.AFFILIATE,
            "", 0, 1, CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrder2Async("", "", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrderUpsells2Async("", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ChangeAddressOrder2Async("","","","","", "", "", "", "", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ChangeDateOrderAsync("", DateOnly.FromDateTime(DateTime.Now), "",  cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ChangeProductOrder2Async("", "", "", false, false, DateOnly.FromDateTime(DateTime.Now), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ExtendOrder2Async("", 1, "", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await PauseOrder2Async("", DateOnly.FromDateTime(DateTime.Now), "", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ReinstateOrder2Async("", "", cancellationToken: CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetOrders2Async(cancellationToken: CancellationToken.None));
    }
}
