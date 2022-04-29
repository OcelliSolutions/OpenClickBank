using System.Linq;
using OpenClickBankTests.Fixtures;
using OpenClickBankTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace OpenClickBankTests;

[Collection("Shared collection")]
public class ProductTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public ProductTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact]
    async public void GetProductsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var productList =
            await Fixture.ApiKey.ClickBankService.Products.GetProductsAsync(Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(productList,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(productList.Total_record_count == 0, "WARN: No data returned. Could not test");

        var firstProduct = productList.Products?.Product?.First();
        if (firstProduct == null) return;
        var product =
            await Fixture.ApiKey.ClickBankService.Products.GetProductAsync(firstProduct.Sku!, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(product, Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }
}
