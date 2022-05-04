using Ocelli.OpenClickBankTests.Fixtures;
using Xunit;

namespace Ocelli.OpenClickBankTests;

[Collection("Shared collection")]
public class DebugTests : IClassFixture<SharedFixture>
{
    public DebugTests(SharedFixture sharedFixture) => Fixture = sharedFixture;

    private SharedFixture Fixture { get; }

    [Fact]
    async public void GetDebugsAsync_ReturnsStringWhenAuthorized_ShouldPass()
    {
        var debug = await Fixture.ApiKey.ClickBankService.Debugs.GetDebugAsync();
        Assert.Contains(Fixture.ApiKey.OpenClickBankConfig.DeveloperApiKey, debug);
        Assert.Contains(Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey, debug);
        Assert.Contains("HAS_DEVELOPER_KEY", debug);
    }
}
