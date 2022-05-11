namespace Ocelli.OpenClickBank;

public partial class ClickBankService : IAnalyticsClient
{
    public Task<AnalyticStatus?> GetStatusAsync(CancellationToken cancellationToken = default) =>
        Analytics.GetStatusAsync(cancellationToken);

    public Task<SubscriptionDetailResult?> GetSubscriptionDetailsCompletingIn30DaysAsync(RoleAccount role,
        string account, SubscriptionDetailRowOrderBy? orderBy = null, SortDirection? sortDirection = null,
        CancellationToken cancellationToken = default) =>
        Analytics.GetSubscriptionDetailsCompletingIn30DaysAsync(role, account, orderBy, sortDirection,
            cancellationToken);

    public Task<SubscriptionDetailResult?> GetSubscriptionDetailsCompletingIn60DaysAsync(RoleAccount role,
        string account, SubscriptionDetailRowOrderBy? orderBy = null, SortDirection? sortDirection = null,
        CancellationToken cancellationToken = default) =>
        Analytics.GetSubscriptionDetailsCompletingIn60DaysAsync(role, account, orderBy, sortDirection,
            cancellationToken);

    public Task<SubscriptionDetailResult?> GetSubscriptionDetailsCanceledLast30DaysAsync(RoleAccount role,
        string account,
        SubscriptionDetailRowOrderBy? orderBy = null, SortDirection? sortDirection = null,
        CancellationToken cancellationToken = default) =>
        Analytics.GetSubscriptionDetailsCanceledLast30DaysAsync(role, account, orderBy, sortDirection,
            cancellationToken);

    public Task<SubscriptionDetailResult?> GetSubscriptionDetailsCanceledLast60DaysAsync(RoleAccount role,
        string account,
        SubscriptionDetailRowOrderBy? orderBy = null, SortDirection? sortDirection = null,
        CancellationToken cancellationToken = default) =>
        Analytics.GetSubscriptionDetailsCanceledLast60DaysAsync(role, account, orderBy, sortDirection,
            cancellationToken);

    public Task<SubscriptionDetailResult?> GetSubscriptionDetailsByStartDateAsync(RoleAccount role, string account,
        DateTimeOffset startDate,
        DateTimeOffset endDate, SubscriptionDetailRowOrderBy? orderBy = null, SortDirection? sortDirection = null,
        CancellationToken cancellationToken = default) =>
        Analytics.GetSubscriptionDetailsByStartDateAsync(role, account, startDate, endDate, orderBy, sortDirection,
            cancellationToken);

    public Task<SubscriptionDetailResult?> GetSubscriptionDetailsByCancelDateAsync(RoleAccount role, string account,
        DateTimeOffset startDate,
        DateTimeOffset endDate, SubscriptionDetailRowOrderBy? orderBy = null, SortDirection? sortDirection = null,
        CancellationToken cancellationToken = default) =>
        Analytics.GetSubscriptionDetailsByCancelDateAsync(role, account, startDate, endDate, orderBy, sortDirection,
            cancellationToken);

    public Task<SubscriptionDetailResult?> GetSubscriptionDetailsByNextPaymentDateAsync(RoleAccount role, string account,
        DateTimeOffset startDate,
        DateTimeOffset endDate, SubscriptionDetailRowOrderBy? orderBy = null, SortDirection? sortDirection = null,
        CancellationToken cancellationToken = default) =>
        Analytics.GetSubscriptionDetailsByNextPaymentDateAsync(role, account, startDate, endDate, orderBy,
            sortDirection, cancellationToken);

    public Task<SubscriptionDetailResult?> GetSubscriptionDetailsByStatusDateAsync(RoleAccount role, string account,
        SubscriptionStatus status,
        SubscriptionDetailRowOrderBy? orderBy = null, SortDirection? sortDirection = null,
        CancellationToken cancellationToken = default) =>
        Analytics.GetSubscriptionDetailsByStatusDateAsync(role, account, status, orderBy, sortDirection,
            cancellationToken);

    public Task<SubscriptionDetailResult?> GetSubscriptionDetailsAsync(RoleAccount role, string account,
        SubscriptionDetailRowOrderBy? orderBy = null,
        SortDirection? sortDirection = null, CancellationToken cancellationToken = default) =>
        Analytics.GetSubscriptionDetailsAsync(role, account, orderBy, sortDirection, cancellationToken);

    public Task<SubscriptionTrendsData?> GetSubscriptionTrendsAsync(RoleAccount role, string account,
        DateTimeOffset startDate, DateTimeOffset endDate,
        string? groupBy = null, int? productId = null, int? page = 1,
        CancellationToken cancellationToken = default) =>
        Analytics.GetSubscriptionTrendsAsync(role, account, startDate, endDate, groupBy, productId, page,
            cancellationToken);

    public Task<AnalyticsResult?> GetStatisticsByRoleAndDimensionAsync(RoleAccount role, Dimension dimension,
        string account, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, Dimension? dimensionFilter = null,
        IEnumerable<DimensionColumn>? select = null, DimensionColumn? orderBy = null, bool? sortAscending = null, int? page = 1,
        CancellationToken cancellationToken = default) =>
        Analytics.GetStatisticsByRoleAndDimensionAsync(role, dimension, account, startDate, endDate,
            dimensionFilter, select, orderBy, sortAscending, page, cancellationToken);

    public Task<AnalyticsResult?> GetStatisticsByRoleAndDimensionSummaryAsync(RoleAccount role,
        Dimension dimension, string account,
        SummaryType summaryType, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null,
        Dimension? dimensionFilter = null, IEnumerable<DimensionColumn>? select = null,
        DimensionColumn? orderBy = null, bool? sortAscending = null, int? page = 1, 
        CancellationToken cancellationToken = default) =>
        Analytics.GetStatisticsByRoleAndDimensionSummaryAsync(role, dimension, account, summaryType, startDate,
            endDate, dimensionFilter, select, orderBy, sortAscending, page, cancellationToken);
}