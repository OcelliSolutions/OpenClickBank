using System.Diagnostics;

namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("ShippingTests")]
public class ShippingTests : IClassFixture<SharedFixture>
{
    private SharedFixture Fixture { get; }
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ShippingMockClient _badRequestMockClient;
    private readonly ShippingMockClient _okEmptyMockClient;
    private readonly ShippingMockClient _okInvalidJsonMockClient;

    public ShippingTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ShippingMockClient(sharedFixture.BadRequestMockHttpClient);
        _okEmptyMockClient = new ShippingMockClient(sharedFixture.OkEmptyMockHttpClient);
        _okInvalidJsonMockClient = new ShippingMockClient(sharedFixture.OkInvalidJsonMockHttpClient);
    }

    [SkippableFact]
    public async Task GetShippingAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var results = new List<OrderShipData>();
        var hasMoreData = false;
        var page = 1;
        do
        {
            var shippingListResult =
                await Fixture.ApiKey.ClickBankService.Shipping.GetShippingAsync(days:10, page: page);
            _additionalPropertiesHelper.CheckAdditionalProperties(shippingListResult,
                Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
            Assert.NotNull(shippingListResult?.OrderShipData);
            Debug.Assert(shippingListResult?.OrderShipData != null, "shippingListResult.OrderShipData != null");
            Skip.If(!shippingListResult.OrderShipData.Any(), "WARN: No data returned. Could not test");
            
            if (shippingListResult.OrderShipData != null) results.AddRange(shippingListResult.OrderShipData);
            hasMoreData = shippingListResult.HasMoreData;
            page++;
        } while (hasMoreData);
        _testOutputHelper.WriteLine($@"Shipping Tested: {results.Count}");
    }

    [SkippableFact]
    public async Task GetShippingCountAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var count =
            await Fixture.ApiKey.ClickBankService.Shipping.GetShippingCountAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(count,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Assert.NotEqual(0, count);
    }

    //TODO: The required parameter of `receipt` is not available.
    [Fact(Skip = "TODO: The required parameter of `receipt` is not available.")]
    public async Task GetShippingNoticeAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var shippingNoticeData =
            await Fixture.ApiKey.ClickBankService.Shipping.GetShippingNoticeAsync(Fixture.Receipt);
        _additionalPropertiesHelper.CheckAdditionalProperties(shippingNoticeData,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Assert.NotNull(shippingNoticeData?.Receipt);
    }

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class ShippingMockClient : Shipping2Client, IMockTests
{
    public ShippingMockClient(HttpClient httpClient) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await GetShippingCountAsync(cancellationToken: CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetShippingCountAsync(cancellationToken: CancellationToken.None));
    }
}

