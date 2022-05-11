using System.Collections.Generic;
using Ocelli.OpenClickBank;
using Ocelli.OpenClickBankTests.Fixtures;
using Ocelli.OpenClickBankTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenClickBankTests;

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
        var results = new List<ImageData>();
        var hasMoreData = false;
        int totalResults;
        var page = 1;
        do
        {
            var imageListResult =
                await Fixture.ApiKey.ClickBankService.Images.GetImagesAsync(Fixture.ApiKey.Site, page:page);
            _additionalPropertiesHelper.CheckAdditionalProperties(imageListResult,
                Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
            if (imageListResult?.ImageList is { Images: { } }) results.AddRange(imageListResult.ImageList.Images!);
            hasMoreData = imageListResult?.HasMoreData ?? false;
            totalResults = imageListResult?.Total_record_count ?? 0;
            page++;
            Skip.If(imageListResult?.Total_record_count == 0, "WARN: No data returned. Could not test");
        } while (hasMoreData);

        Assert.Equal(totalResults, results.Count);
    }
}
