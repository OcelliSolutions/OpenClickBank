using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ocelli.OpenClickBank;
using Ocelli.OpenClickBankTests.Fixtures;
using Ocelli.OpenClickBankTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenClickBankTests;

[Collection("Shared collection")]
public class OrderTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public OrderTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }
    private readonly ITestOutputHelper _testOutputHelper;

    [Fact]
    async public void GetOrdersAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var results = new List<OrderData>();
        var hasMoreData = false;
        var page = 1;
        do
        {
            var orders =
                await Fixture.ApiKey.ClickBankService.Orders.GetOrdersAsync(startDate: DateTimeOffset.Now.AddDays(-1),
                    endDate: DateTimeOffset.Now, page: page);
            Debug.Assert(orders.OrderData != null, "orders.OrderData != null");
            Assert.NotEmpty(orders.OrderData);
            foreach (var order in orders.OrderData)
                _additionalPropertiesHelper.CheckAdditionalProperties(order,
                    Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
            if (orders.OrderData != null) results.AddRange(orders.OrderData);
            hasMoreData = orders.HasMoreData;
            page++;
        } while (hasMoreData);
        _testOutputHelper.WriteLine($@"Orders Tested: {results.Count}");
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
