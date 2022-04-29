using System;
using System.Diagnostics;
using System.Linq;
using OpenClickBank;
using OpenClickBankTests.Fixtures;
using OpenClickBankTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace OpenClickBankTests;

[Collection("Shared collection")]
public class AnalyticTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public AnalyticTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact]
    async public void GetStatusAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetStatusAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(string.IsNullOrWhiteSpace(analyticStatus.Status), "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsCompletingIn30DaysAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCompletingIn30DaysAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsCompletingIn30DaysAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCompletingIn30DaysAsync(
                RoleAccount.VENDOR, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsCompletingIn60DaysAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCompletingIn60DaysAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsCompletingIn60DaysAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCompletingIn60DaysAsync(
                RoleAccount.VENDOR, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsCanceledLast30DaysAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCanceledLast30DaysAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsCanceledLast30DaysAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCanceledLast30DaysAsync(
                RoleAccount.VENDOR, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsCanceledLast60DaysAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCanceledLast60DaysAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsCanceledLast60DaysAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCanceledLast60DaysAsync(
                RoleAccount.VENDOR, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsByStartDateAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStartDateAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsByStartDateAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStartDateAsync(RoleAccount.VENDOR,
                Fixture.ApiKey.Site, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsByCancelDateAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByCancelDateAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsByCancelDateAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByCancelDateAsync(RoleAccount.VENDOR,
                Fixture.ApiKey.Site, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsByNextPaymentDateAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByNextPaymentDateAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsByNextPaymentDateAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByNextPaymentDateAsync(
                RoleAccount.VENDOR, Fixture.ApiKey.Site, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsByStatusDateAsync_AFFILIATE_ACTIVE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStatusDateAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site, SubscriptionStatus.ACTIVE);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void
        GetSubscriptionDetailsByStatusDateAsync_AFFILIATE_COMPLETED_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStatusDateAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site, SubscriptionStatus.COMPLETED);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsByStatusDateAsync_VENDOR_ACTIVE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStatusDateAsync(RoleAccount.VENDOR,
                Fixture.ApiKey.Site, SubscriptionStatus.ACTIVE);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsByStatusDateAsync_VENDOR_COMPLETED_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStatusDateAsync(RoleAccount.VENDOR,
                Fixture.ApiKey.Site, SubscriptionStatus.COMPLETED);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsAsync(RoleAccount.AFFILIATE,
                Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionDetailsAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsAsync(RoleAccount.VENDOR,
                Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionTrendsAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionTrendsAsync(RoleAccount.AFFILIATE,
                Fixture.ApiKey.Site, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    async public void GetSubscriptionTrendsAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionTrendsAsync(RoleAccount.VENDOR,
                Fixture.ApiKey.Site, DateTimeOffset.Now.AddDays(-30), DateTimeOffset.Now);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus.TotalCount == 0, "WARN: No data returned. Could not test");
    }
    
    [SkippableFact]
    async public void
        GetStatisticsByRoleAndDimensionAsync_AFFILIATE_CUSTOMER_COUNTRY_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetStatisticsByRoleAndDimensionAsync(RoleAccount.AFFILIATE,
                Dimension.CUSTOMER_COUNTRY, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(!analyticStatus.Rows?.Row?.Any() ?? true, "WARN: No data returned. Could not test");
        if (!analyticStatus.Rows?.Row?.Any() ?? true) return;
        Debug.Assert(analyticStatus.Rows != null, "analyticStatus.Rows != null");
        Debug.Assert(analyticStatus.Rows.Row != null, "analyticStatus.Rows.Row != null");
        foreach (var row in analyticStatus.Rows.Row)
        {
            Debug.Assert(row.Data != null, "row.Data != null");
            foreach (var data in row.Data)
            {
                Assert.NotNull(data.Attribute);
                Assert.NotNull(data.Value?.Type);
                Assert.NotNull(data.Value?.Dollar);
            }
        }
    }
    
    [SkippableFact]
    async public void
        GetStatisticsByRoleAndDimensionAsync_VENDOR_CUSTOMER_COUNTRY_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetStatisticsByRoleAndDimensionAsync(RoleAccount.VENDOR,
                Dimension.CUSTOMER_COUNTRY, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(!analyticStatus.Rows?.Row?.Any() ?? true, "WARN: No data returned. Could not test");
        if (!analyticStatus.Rows?.Row?.Any() ?? true) return;
        Debug.Assert(analyticStatus.Rows != null, "analyticStatus.Rows != null");
        Debug.Assert(analyticStatus.Rows.Row != null, "analyticStatus.Rows.Row != null");
        foreach (var row in analyticStatus.Rows.Row)
        {
            Debug.Assert(row.Data != null, "row.Data != null");
            foreach (var data in row.Data)
            {
                Assert.NotNull(data.Attribute);
                Assert.NotNull(data.Value?.Type);
                Assert.NotNull(data.Value?.Dollar);
            }
        }
    }
    
    [SkippableFact]
    async public void
        GetStatisticsByRoleAndDimensionSummaryAsync_AFFILIATE_PRODUCT_SKU_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetStatisticsByRoleAndDimensionSummaryAsync(
                RoleAccount.AFFILIATE,
                Dimension.AFFILIATE, Fixture.ApiKey.Site, SummaryType.VENDOR_ONLY);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(!analyticStatus.Rows?.Row?.Any() ?? true, "WARN: No data returned. Could not test");
        if (!analyticStatus.Rows?.Row?.Any() ?? true) return;
        Debug.Assert(analyticStatus.Rows != null, "analyticStatus.Rows != null");
        Debug.Assert(analyticStatus.Rows.Row != null, "analyticStatus.Rows.Row != null");
        foreach (var row in analyticStatus.Rows.Row)
        {
            Debug.Assert(row.Data != null, "row.Data != null");
            foreach (var data in row.Data)
            {
                Assert.NotNull(data.Attribute);
                Assert.NotNull(data.Value?.Type);
                Assert.NotNull(data.Value?.Dollar);
            }
        }
    }

    [SkippableFact]
    async public void
        GetStatisticsByRoleAndDimensionSummaryAsync_VENDOR_PRODUCT_SKU_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetStatisticsByRoleAndDimensionSummaryAsync(
                RoleAccount.VENDOR,
                Dimension.PRODUCT_SKU, Fixture.ApiKey.Site, SummaryType.VENDOR_ONLY);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(!analyticStatus.Totals?.Total?.Any() ?? true, "WARN: No data returned. Could not test");
        if (!analyticStatus.Totals?.Total?.Any() ?? true) return;
        Debug.Assert(analyticStatus.Totals != null, "analyticStatus.Rows != null");
        Debug.Assert(analyticStatus.Totals.Total != null, "analyticStatus.Rows.Row != null");
        foreach (var row in analyticStatus.Totals.Total)
        {
            Assert.NotNull(row.Attribute);
            Assert.NotNull(row.Value?.Type);
            Assert.NotNull(row.Value?.Dollar);
        }
    }
}
