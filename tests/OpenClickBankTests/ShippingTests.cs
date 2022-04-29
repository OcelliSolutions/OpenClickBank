﻿using System.Diagnostics;
using System.Linq;
using OpenClickBankTests.Fixtures;
using OpenClickBankTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace OpenClickBankTests;

[Collection("Shared collection")]
public class ShippingTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public ShippingTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact]
    async public void GetShippingAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var shippingListResult =
            await Fixture.ApiKey.ClickBankService.Shipping.GetShippingAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(shippingListResult,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Assert.NotNull(shippingListResult.OrderShipData);
        Debug.Assert(shippingListResult.OrderShipData != null, "shippingListResult.OrderShipData != null");
        Skip.If(!shippingListResult.OrderShipData.Any(), "WARN: No data returned. Could not test");
    }

    [Fact]
    async public void GetShippingCountAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var count =
            await Fixture.ApiKey.ClickBankService.Shipping.GetShippingCountAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(count,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Assert.NotEqual(0, count);
    }

    [Fact(Skip = "TODO: The required parameter of `receipt` is not available.")]
    async public void GetShippingNoticeAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var receipt = string.Empty;
        var shippingNoticeData =
            await Fixture.ApiKey.ClickBankService.Shipping.GetShippingNoticeAsync(receipt);
        _additionalPropertiesHelper.CheckAdditionalProperties(shippingNoticeData,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Assert.NotNull(shippingNoticeData.Receipt);
    }
}
