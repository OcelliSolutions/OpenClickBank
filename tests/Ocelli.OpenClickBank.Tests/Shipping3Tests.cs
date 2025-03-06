using System.Diagnostics;

namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("ShippingTests")]
public class Shipping3Tests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    : IClassFixture<SharedFixture>
{
    private SharedFixture Fixture { get; } = sharedFixture;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper = new(testOutputHelper);
    private readonly Shipping3MockClient _badRequestMockClient = new(sharedFixture.BadRequestMockHttpClient);
    private readonly Shipping3MockClient _okEmptyMockClient = new(sharedFixture.OkEmptyMockHttpClient);
    private readonly Shipping3MockClient _okInvalidJsonMockClient = new(sharedFixture.OkInvalidJsonMockHttpClient);

    #region Read
    
    [SkippableFact]
    public async Task GetShippingAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var results = new List<OrderShipData>();
        var hasMoreData = false;
        var page = 1;
        do
        {
            var shippingListResult =
                await Fixture.ApiKey.ClickBankService.Shipping.GetShippingsAsync(days:30, page: page);
            _additionalPropertiesHelper.CheckAdditionalProperties(shippingListResult,
                Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
            Assert.NotNull(shippingListResult.Result?.OrderShipData);
            Debug.Assert(shippingListResult.Result.OrderShipData != null, "shippingListResult.OrderShipData != null");
            Skip.If(!shippingListResult.Result.OrderShipData.Any(), "WARN: No data returned. Could not test");
            
            if (shippingListResult.Result.OrderShipData != null) results.AddRange(shippingListResult.Result.OrderShipData);
            hasMoreData = shippingListResult.HasMoreData;
            page++;
        } while (hasMoreData);
        testOutputHelper.WriteLine($@"Shipping Tested: {results.Count}");
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
    [SkippableFact]
    public async Task GetShippingNoticeAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        //ClickBank will just keep adding shipping notifications without checking first. For testing only create up to 2 instances.
        var initialCheck =
            await Fixture.ApiKey.ClickBankService.Shipping.GetShipNoticeAsync(Fixture.Receipt);

        if (initialCheck?.ShippingNoticeData == null || initialCheck.ShippingNoticeData.Count < 2)
        {
            var request = await Fixture.ApiKey.ClickBankService.Shipping.CreateShipNoticeAsync(Fixture.Receipt,
                DateOnly.FromDateTime(DateTime.UtcNow), "ups", tracking: "sample", comments: "test", fillOrder: false);
            _additionalPropertiesHelper.CheckAdditionalProperties(request,
                Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        }

        var response =
            await Fixture.ApiKey.ClickBankService.Shipping.GetShipNoticeAsync(Fixture.Receipt);
        _additionalPropertiesHelper.CheckAdditionalProperties(response,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(response == null, "No shipping notice found for this receipt.");
        Skip.If(response.ShippingNoticeData == null, "No shipping notice found for this receipt.");
        Skip.If(!response.ShippingNoticeData.Any(), "No shipping notice found for this receipt.");
    }

    #endregion Read

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class Shipping3MockClient : Shipping3Client, IMockTests
{
    public Shipping3MockClient(HttpClient httpClient) : base(httpClient)
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

