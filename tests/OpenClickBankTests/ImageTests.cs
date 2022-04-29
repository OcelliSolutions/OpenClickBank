using OpenClickBankTests.Fixtures;
using OpenClickBankTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace OpenClickBankTests;

[Collection("Shared collection")]
public class ImageTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public ImageTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact]
    async public void GetStatusAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var imageListResult =
            await Fixture.ApiKey.ClickBankService.Images.GetImagesAsync(Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(imageListResult,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(imageListResult.Total_record_count == 0, "WARN: No data returned. Could not test");
    }
}
