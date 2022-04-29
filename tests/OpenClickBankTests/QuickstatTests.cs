using System.Linq;
using OpenClickBankTests.Fixtures;
using OpenClickBankTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace OpenClickBankTests;

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
    async public void GetAccountAsync_ReturnsAccountWhenAuthorized_ShouldPass()
    {
        var stats = await Fixture.ApiKey.ClickBankService.Quickstats.GetAccountAsync();
        Assert.NotNull(stats.AccountData!.NickName);
        Assert.Null(stats.AccountData!.QuickStats);

        _additionalPropertiesHelper.CheckAdditionalProperties(stats, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    [Fact]
    async public void GetQuickstatsAsync_ReturnsAccountWhenAuthorized_ShouldPass()
    {
        var stats = await Fixture.ApiKey.ClickBankService.Quickstats.GetQuickstatsAsync();
        Assert.NotNull(stats.AccountData!.NickName);
        Assert.NotNull(stats.AccountData!.QuickStats);
        Assert.NotEmpty(stats.AccountData!.QuickStats!);

        _additionalPropertiesHelper.CheckAdditionalProperties(stats, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }
    
    [Fact]
    async public void GetQuickstatsSummaryAsync_ReturnsAccountWhenAuthorized_ShouldPass()
    {
        var stats = await Fixture.ApiKey.ClickBankService.Quickstats.GetQuickstatsSummaryAsync();
        Assert.NotNull(stats.AccountData!.NickName);
        Assert.NotNull(stats.AccountData!.QuickStats);
        Assert.NotEmpty(stats.AccountData!.QuickStats!);
        Assert.Null(stats.AccountData!.QuickStats?.First().QuickStatDate);

        _additionalPropertiesHelper.CheckAdditionalProperties(stats, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }
}
