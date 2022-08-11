namespace Ocelli.OpenClickBankTests;

[Collection("Shared collection")]
public class QuickstatTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public QuickstatTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [Fact]
    public async Task GetAccountAsync_ReturnsAccountWhenAuthorized_ShouldPass()
    {
        var stats = await Fixture.ApiKey.ClickBankService.Quickstats.GetAccountAsync();
        foreach (var accountData in stats?.AccountData!)
        {
            Assert.NotNull(accountData.NickName);
            Assert.Null(accountData.QuickStats);
        }
        _additionalPropertiesHelper.CheckAdditionalProperties(stats, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    [Fact]
    public async Task GetQuickstatsAsync_ReturnsAccountWhenAuthorized_ShouldPass()
    {
        var stats = await Fixture.ApiKey.ClickBankService.Quickstats.GetQuickstatsAsync();
        foreach (var accountData in stats?.AccountData!)
        {
            Assert.NotNull(accountData.NickName);
            Assert.NotNull(accountData.QuickStats);
            Assert.NotEmpty(accountData.QuickStats!);
        }
        _additionalPropertiesHelper.CheckAdditionalProperties(stats, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }
    
    [Fact]
    public async Task GetQuickstatsSummaryAsync_ReturnsAccountWhenAuthorized_ShouldPass()
    {
        var stats = await Fixture.ApiKey.ClickBankService.Quickstats.GetQuickstatsSummaryAsync();
        foreach (var accountData in stats?.AccountData!)
        {
            Assert.NotNull(accountData.NickName);
            Assert.NotNull(accountData.QuickStats);
            Assert.NotEmpty(accountData.QuickStats!);
            Assert.Null(accountData.QuickStats?.First().QuickStatDate);
        }
        _additionalPropertiesHelper.CheckAdditionalProperties(stats, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }
}
