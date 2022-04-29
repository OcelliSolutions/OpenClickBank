using System;
using System.Diagnostics;
using OpenClickBankTests.Fixtures;
using OpenClickBankTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace OpenClickBankTests;

[Collection("Shared collection")]
public class OrderTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public OrderTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [Fact]
    async public void GetOrdersAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var orders =
            await Fixture.ApiKey.ClickBankService.Orders.GetOrdersAsync(startDate: DateTimeOffset.Now.AddDays(-1),
                endDate: DateTimeOffset.Now);
        Debug.Assert(orders.OrderData != null, "orders.OrderData != null");
        Assert.NotEmpty(orders.OrderData);
        foreach (var order in orders.OrderData)
            _additionalPropertiesHelper.CheckAdditionalProperties(order,
                Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
    }

    [Fact]
    async public void GetOrderCountAsync_ReturnNumber_ShouldPass()
    {
        var orders =
            await Fixture.ApiKey.ClickBankService.Orders.GetOrderCountAsync(DateTimeOffset.Now.AddDays(-10),
                DateTimeOffset.Now);
        Assert.NotEqual(0, orders);
    }
}
