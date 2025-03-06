namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("DebugTests")]
public class DebugTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    : IClassFixture<SharedFixture>
{
    private SharedFixture Fixture { get; } = sharedFixture;
    private readonly DebugMockClient _badRequestMockClient = new(sharedFixture.BadRequestMockHttpClient);
    private readonly DebugMockClient _okEmptyMockClient = new(sharedFixture.OkEmptyMockHttpClient);

    [SkippableFact]
    public async Task GetDebugsAsync_ReturnsStringWhenAuthorized_ShouldPass()
    {
        var debug = await Fixture.ApiKey.ClickBankService.Debugs.GetDebugAsync();
        Assert.Contains(Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey, debug);
        Assert.Contains("HAS_DEVELOPER_KEY", debug);
    }

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class DebugMockClient : DebugClient, IMockTests
{
    public DebugMockClient(HttpClient httpClient) : base(httpClient) => BaseUrl = "https://localhost";

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        await Assert.ThrowsAsync<ApiException>(async () => await GetDebugAsync(cancellationToken: CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetDebugAsync(cancellationToken: CancellationToken.None));
    }
}
