﻿namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("ImageTests")]
public class ImageTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    : IClassFixture<SharedFixture>
{
    private SharedFixture Fixture { get; } = sharedFixture;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper = new(testOutputHelper);
    private readonly ImageMockClient _badRequestMockClient = new(sharedFixture.BadRequestMockHttpClient);
    private readonly ImageMockClient _okEmptyMockClient = new(sharedFixture.OkEmptyMockHttpClient);
    private readonly ImageMockClient _okInvalidJsonMockClient = new(sharedFixture.OkInvalidJsonMockHttpClient);

    [SkippableFact]
    public async Task GetStatusAsync_AdditionalPropertiesAreEmpty_ShouldPass()
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
            if (imageListResult.Result?.ImageList is { Images: { } }) results.AddRange(imageListResult.Result.ImageList.Images!);
            hasMoreData = imageListResult.HasMoreData;
            totalResults = imageListResult.Result?.Total_record_count ?? 0;
            page++;
            Skip.If(imageListResult.Result?.Total_record_count == 0, "WARN: No data returned. Could not test");
        } while (hasMoreData);

        Assert.Equal(totalResults, results.Count);
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

internal class ImageMockClient : ImagesClient, IMockTests
{
    public ImageMockClient(HttpClient httpClient) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await GetImagesAsync(site: "", cancellationToken: CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetImagesAsync(site: "", cancellationToken: CancellationToken.None));
    }
}

