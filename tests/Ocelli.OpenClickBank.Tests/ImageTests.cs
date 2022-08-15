namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("ImageTests")]
public class ImageTests : IClassFixture<SharedFixture>
{
    private SharedFixture Fixture { get; }
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ImageMockClient _badRequestMockClient;
    private readonly ImageMockClient _okEmptyMockClient;
    private readonly ImageMockClient _okInvalidJsonMockClient;

    public ImageTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ImageMockClient(sharedFixture.BadRequestMockHttpClient);
        _okEmptyMockClient = new ImageMockClient(sharedFixture.OkEmptyMockHttpClient);
        _okInvalidJsonMockClient = new ImageMockClient(sharedFixture.OkInvalidJsonMockHttpClient);
    }

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
            if (imageListResult?.ImageList is { Images: { } }) results.AddRange(imageListResult.ImageList.Images!);
            hasMoreData = imageListResult?.HasMoreData ?? false;
            totalResults = imageListResult?.Total_record_count ?? 0;
            page++;
            Skip.If(imageListResult?.Total_record_count == 0, "WARN: No data returned. Could not test");
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

internal class ImageMockClient : ImageClient, IMockTests
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

