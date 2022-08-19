namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("QuickstatTests")]
public class QuickstatTests : IClassFixture<SharedFixture>
{
    private SharedFixture Fixture { get; }
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly QuickstatMockClient _badRequestMockClient;
    private readonly QuickstatMockClient _okEmptyMockClient;
    private readonly QuickstatMockClient _okInvalidJsonMockClient;

    public QuickstatTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new QuickstatMockClient(sharedFixture.BadRequestMockHttpClient);
        _okEmptyMockClient = new QuickstatMockClient(sharedFixture.OkEmptyMockHttpClient);
        _okInvalidJsonMockClient = new QuickstatMockClient(sharedFixture.OkInvalidJsonMockHttpClient);
    }

    [SkippableFact]
    public async Task GetAccountAsync_ReturnsAccountWhenAuthorized_ShouldPass()
    {
        var stats = await Fixture.ApiKey.ClickBankService.Quickstats.GetAccountsAsync();
        foreach (var accountData in stats?.AccountData!)
        {
            Assert.NotNull(accountData.NickName);
            Assert.Null(accountData.QuickStats);
        }
        _additionalPropertiesHelper.CheckAdditionalProperties(stats, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    [SkippableFact]
    public async Task GetQuickstatsAsync_ReturnsAccountWhenAuthorized_ShouldPass()
    {
        var stats = await Fixture.ApiKey.ClickBankService.Quickstats.GetQuickstatsAsync();
        Skip.If(stats == null, "No results returned. Unable to test.");
        foreach (var accountData in stats?.AccountData!)
        {
            Assert.NotNull(accountData.NickName);
            Assert.NotNull(accountData.QuickStats);
            Assert.NotEmpty(accountData.QuickStats!);
        }
        _additionalPropertiesHelper.CheckAdditionalProperties(stats, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }
    
    [SkippableFact]
    public async Task GetQuickstatsCountAsync_ReturnsAccountWhenAuthorized_ShouldPass()
    {
        var stats = await Fixture.ApiKey.ClickBankService.Quickstats.GetQuickstatsCountAsync();
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

internal class QuickstatMockClient : QuickstatsClient, IMockTests
{
    public QuickstatMockClient(HttpClient httpClient) : base(httpClient) => BaseUrl = "https://localhost";

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        await Assert.ThrowsAsync<ApiException>(async () => await GetAccountsAsync(cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetQuickstatsAsync(DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now), "", CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetAccountsAsync(cancellationToken: CancellationToken.None));
    }
}
