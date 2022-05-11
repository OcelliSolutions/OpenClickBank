using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ocelli.OpenClickBank;
using Ocelli.OpenClickBankTests.Fixtures;
using Ocelli.OpenClickBankTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenClickBankTests;

[Collection("Shared collection")]
public class ProductTests : IClassFixture<SharedFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public ProductTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact]
    async public void GetProductsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
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
            Skip.If(productList?.Total_record_count == 0, "WARN: No data returned. Could not test");

            if (productList != null)
            {
                var firstProduct = productList.Products?.Product?.First();
                if (firstProduct == null) return;
                var product =
                    await Fixture.ApiKey.ClickBankService.Products.GetProductAsync(firstProduct.Sku!,
                        Fixture.ApiKey.Site);
                _additionalPropertiesHelper.CheckAdditionalProperties(product,
                    Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);

                if (productList.Products?.Product != null) results.AddRange(productList.Products.Product!);
            }

            hasMoreData = productList?.HasMoreData ?? false;
            page++;
        } while (hasMoreData);
        _testOutputHelper.WriteLine($@"Products Tested: {results.Count}");
    }
}
