namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("ProductTests")]
public class ProductTests : IClassFixture<SharedFixture>
{
    private string _sku => "SAMP01";
    private SharedFixture Fixture { get; }
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ProductMockClient _badRequestMockClient;
    private readonly ProductMockClient _okEmptyMockClient;
    private readonly ProductMockClient _okInvalidJsonMockClient;

    public ProductTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ProductMockClient(sharedFixture.BadRequestMockHttpClient);
        _okEmptyMockClient = new ProductMockClient(sharedFixture.OkEmptyMockHttpClient);
        _okInvalidJsonMockClient = new ProductMockClient(sharedFixture.OkInvalidJsonMockHttpClient);
    }

    #region Create
    /*
    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateProductAsync_CanCreate() =>
        await Fixture.ApiKey.ClickBankService.Products.CreateProductAsync(
            sku: _sku,
            site: Fixture.ApiKey.Site, 
            currency: Currency.USD, 
            price: 9.99, 
            title: "OpenClickBank Sample", 
            language: Language.EN, 
            digital: true,
            categories: new List<ProductCategory>() { ProductCategory.EBOOK, ProductCategory.SOFTWARE },
            thankYouPage: "https://sample.com/thankyou?id=SAMP01",
            pitchPage: "https://sample.com/product/SAMP01");
    */
    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetProductsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var results = new List<Product>();
        var hasMoreData = false;
        var page = 1;
        do
        {
            var productList =
                await Fixture.ApiKey.ClickBankService.Products.GetProductsAsync(Fixture.ApiKey.Site, page: page);
            _additionalPropertiesHelper.CheckAdditionalProperties(productList,
                Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
            Skip.If(productList.Result?.Total_record_count == 0, "WARN: No data returned. Could not test");

            if (productList != null)
            {
                var firstProduct = productList.Result?.Products?.Product?.First();
                if (firstProduct == null) return;
                var product =
                    await Fixture.ApiKey.ClickBankService.Products.GetProductAsync(firstProduct.Sku!,
                        Fixture.ApiKey.Site);
                _additionalPropertiesHelper.CheckAdditionalProperties(product,
                    Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);

                if (productList.Result?.Products?.Product != null) results.AddRange(productList.Result.Products.Product!);
            }
            Assert.NotNull(productList?.Result?.Products?.Product);
            hasMoreData = productList.HasMoreData;
            page++;
        } while (hasMoreData);
        _testOutputHelper.WriteLine($@"Products Tested: {results.Count}");
    }

    [SkippableFact]
    [TestPriority(21)]
    public async Task GetProductAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var response =
            await Fixture.ApiKey.ClickBankService.Products.GetProductAsync(_sku, Fixture.ApiKey.Site,
                CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    #endregion Read

    #region Update
    /*
    [SkippableFact]
    [TestPriority(30)]
    public async Task CreateProductAsync_CanUpdate()
    {
        await Fixture.ApiKey.ClickBankService.Products.CreateProductAsync(
            sku: _sku,
            site: Fixture.ApiKey.Site,
            currency: Currency.USD,
            price: 19.99,
            title: "OpenClickBank Sample",
            language: Language.EN,
            digital: true,
            categories: new List<ProductCategory>() { ProductCategory.EBOOK, ProductCategory.SOFTWARE },
            thankYouPage: "https://sample.com/thankyou?id=SAMP01",
            pitchPage: "https://sample.com/product/SAMP01");
    }
    */
    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteProductAsync_CanDelete() => await Fixture.ApiKey.ClickBankService.Products.DeleteProductAsync(_sku, Fixture.ApiKey.Site, CancellationToken.None);

    #endregion Delete

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class ProductMockClient : ProductsClient, IMockTests
{
    public ProductMockClient(HttpClient httpClient) : base(httpClient)
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
        //The create create/update endpoint is not tested since it does not return JSON.
        await Assert.ThrowsAsync<ApiException>(async () => await GetProductsAsync(site: "", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetProductAsync(site: "", sku: "", cancellationToken: CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetProductsAsync(site: "", cancellationToken: CancellationToken.None));
    }
}
