using System.Diagnostics;

namespace Ocelli.OpenClickBank.Tests;

[TestCaseOrderer("Ocelli.OpenClickBank.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenClickBank.Tests")]
[Collection("AnalyticTests")]
public class AnalyticTests : IClassFixture<SharedFixture>
{
    private SharedFixture Fixture { get; }
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly AnalyticMockClient _badRequestMockClient;
    private readonly AnalyticMockClient _okEmptyMockClient;
    private readonly AnalyticMockClient _okInvalidJsonMockClient;

    public AnalyticTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new AnalyticMockClient(sharedFixture.BadRequestMockHttpClient);
        _okEmptyMockClient = new AnalyticMockClient(sharedFixture.OkEmptyMockHttpClient);
        _okInvalidJsonMockClient = new AnalyticMockClient(sharedFixture.OkInvalidJsonMockHttpClient);
    }

    [SkippableFact]
    public async Task GetStatusAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetStatusAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(string.IsNullOrWhiteSpace(analyticStatus?.Status), "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsCompletingIn30DaysAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCompletingIn30DaysAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsCompletingIn30DaysAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCompletingIn30DaysAsync(
                RoleAccount.VENDOR, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsCompletingIn60DaysAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCompletingIn60DaysAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsCompletingIn60DaysAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCompletingIn60DaysAsync(
                RoleAccount.VENDOR, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsCanceledLast30DaysAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCanceledLast30DaysAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsCanceledLast30DaysAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCanceledLast30DaysAsync(
                RoleAccount.VENDOR, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsCanceledLast60DaysAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCanceledLast60DaysAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsCanceledLast60DaysAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsCanceledLast60DaysAsync(
                RoleAccount.VENDOR, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsByStartDateAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStartDateAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site, DateOnly.FromDateTime(DateTime.Now).AddDays(-30), DateOnly.FromDateTime(DateTime.Now));
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsByStartDateAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStartDateAsync(RoleAccount.VENDOR,
                Fixture.ApiKey.Site, DateOnly.FromDateTime(DateTime.Now).AddDays(-30), DateOnly.FromDateTime(DateTime.Now));
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsByCancelDateAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByCancelDateAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site, DateOnly.FromDateTime(DateTime.Now).AddDays(-30), DateOnly.FromDateTime(DateTime.Now));
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsByCancelDateAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByCancelDateAsync(RoleAccount.VENDOR,
                Fixture.ApiKey.Site, DateOnly.FromDateTime(DateTime.Now).AddDays(-30), DateOnly.FromDateTime(DateTime.Now));
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsByNextPaymentDateAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByNextPaymentDateAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site, DateOnly.FromDateTime(DateTime.Now).AddDays(-30), DateOnly.FromDateTime(DateTime.Now));
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsByNextPaymentDateAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByNextPaymentDateAsync(
                RoleAccount.VENDOR, Fixture.ApiKey.Site, DateOnly.FromDateTime(DateTime.Now).AddDays(-30), DateOnly.FromDateTime(DateTime.Now));
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsByStatusDateAsync_AFFILIATE_ACTIVE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStatusDateAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site, SubscriptionStatus.ACTIVE);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task
        GetSubscriptionDetailsByStatusDateAsync_AFFILIATE_COMPLETED_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStatusDateAsync(
                RoleAccount.AFFILIATE, Fixture.ApiKey.Site, SubscriptionStatus.COMPLETED);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsByStatusDateAsync_VENDOR_ACTIVE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStatusDateAsync(RoleAccount.VENDOR,
                Fixture.ApiKey.Site, SubscriptionStatus.ACTIVE);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsByStatusDateAsync_VENDOR_COMPLETED_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsByStatusDateAsync(RoleAccount.VENDOR,
                Fixture.ApiKey.Site, SubscriptionStatus.COMPLETED);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsAsync(RoleAccount.AFFILIATE,
                Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionDetailsAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionDetailsAsync(RoleAccount.VENDOR,
                Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(analyticStatus?.TotalCount == 0, "WARN: No data returned. Could not test");
    }

    [SkippableFact]
    public async Task GetSubscriptionTrendsAsync_AFFILIATE_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var results = new List<SubscriptionProductRowData>();
        var hasMoreData = false;
        int totalResults;
        var page = 1;
        do
        {
            var analyticStatus =
                await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionTrendsAsync(RoleAccount.AFFILIATE,
                    Fixture.ApiKey.Site, DateOnly.FromDateTime(DateTime.Now).AddDays(-30), DateOnly.FromDateTime(DateTime.Now), page:page);
            _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
                Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);

            if (analyticStatus.Result?.Data is { Row: { } }) results.AddRange(analyticStatus.Result.Data.Row!);
            hasMoreData = analyticStatus.HasMoreData;
            totalResults = analyticStatus.Result?.TotalCount ?? 0;
            page++;
            Skip.If(analyticStatus.Result?.TotalCount == 0, "WARN: No data returned. Could not test");
        } while (hasMoreData);

        Assert.Equal(totalResults, results.Count);
    }

    [SkippableFact]
    public async Task GetSubscriptionTrendsAsync_VENDOR_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var results = new List<SubscriptionProductRowData>();
        var hasMoreData = false;
        int totalResults;
        var page = 1;
        do
        {
            var analyticStatus =
                await Fixture.ApiKey.ClickBankService.Analytics.GetSubscriptionTrendsAsync(RoleAccount.VENDOR,
                    Fixture.ApiKey.Site, DateOnly.FromDateTime(DateTime.Now).AddDays(-30), DateOnly.FromDateTime(DateTime.Now), page:page);
            _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
                Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);

            if (analyticStatus.Result?.Data is { Row: { } }) results.AddRange(analyticStatus.Result.Data.Row!);
            hasMoreData = analyticStatus.HasMoreData;
            totalResults = analyticStatus.Result?.TotalCount ?? 0;
            page++;
            Skip.If(analyticStatus.Result?.TotalCount == 0, "WARN: No data returned. Could not test");
        } while (hasMoreData);

        Assert.Equal(totalResults, results.Count);
    }
    
    [SkippableFact]
    public async Task GetStatisticsByRoleAndDimensionAsync_AFFILIATE_CUSTOMER_COUNTRY_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetStatisticsByRoleAndDimensionAsync(RoleAccount.AFFILIATE,
                Dimension.CUSTOMER_COUNTRY, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(!analyticStatus.Result?.Rows?.Row?.Any() ?? true, "WARN: No data returned. Could not test");
        if (!analyticStatus.Result?.Rows?.Row?.Any() ?? true) return;
        Debug.Assert(analyticStatus.Result?.Rows != null, "analyticStatus.Rows != null");
        Debug.Assert(analyticStatus.Result?.Rows?.Row != null, "analyticStatus.Rows.Row != null");
        foreach (var row in analyticStatus.Result.Rows.Row)
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
    public async Task
        GetStatisticsByRoleAndDimensionAsync_VENDOR_CUSTOMER_COUNTRY_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetStatisticsByRoleAndDimensionAsync(RoleAccount.VENDOR,
                Dimension.CUSTOMER_COUNTRY, Fixture.ApiKey.Site);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(!analyticStatus.Result?.Rows?.Row?.Any() ?? true, "WARN: No data returned. Could not test");
        if (!analyticStatus.Result?.Rows?.Row?.Any() ?? true) return;
        Debug.Assert(analyticStatus.Result?.Rows?.Row != null, "analyticStatus.Rows.Row != null");
        foreach (var row in analyticStatus.Result.Rows.Row)
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
    public async Task
        GetStatisticsByRoleAndDimensionSummaryAsync_VENDOR_PRODUCT_SKU_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var analyticStatus =
            await Fixture.ApiKey.ClickBankService.Analytics.GetStatisticsByRoleAndDimensionSummaryAsync(
                RoleAccount.VENDOR,
                Dimension.PRODUCT_SKU, Fixture.ApiKey.Site, SummaryType.VENDOR_ONLY);
        _additionalPropertiesHelper.CheckAdditionalProperties(analyticStatus,
            Fixture.ApiKey.OpenClickBankConfig.ClerkApiKey);
        Skip.If(!analyticStatus.Result?.Totals?.Total?.Any() ?? true, "WARN: No data returned. Could not test");
        if (!analyticStatus.Result?.Totals?.Total?.Any() ?? true) return;
        Debug.Assert(analyticStatus.Result?.Totals?.Total != null, "analyticStatus.Rows.Row != null");
        foreach (var row in analyticStatus.Result.Totals.Total)
        {
            Assert.NotNull(row.Attribute);
            Assert.NotNull(row.Value?.Type);
            Assert.NotNull(row.Value?.Dollar);
        }
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

internal class AnalyticMockClient : AnalyticsClient, IMockTests
{
    public AnalyticMockClient(HttpClient httpClient) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await GetStatusAsync(cancellationToken: CancellationToken.None));

        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetStatusAsync(cancellationToken: CancellationToken.None));
    }
}
