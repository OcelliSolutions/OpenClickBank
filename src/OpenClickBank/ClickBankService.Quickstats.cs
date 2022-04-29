namespace OpenClickBank;

public partial class ClickBankService : IQuickstatsClient
{
    public Task<AccountList> GetAccountAsync(CancellationToken cancellationToken = default) =>
        Quickstats.GetAccountAsync(cancellationToken);

    public Task<AccountList> GetQuickstatsAsync(CancellationToken cancellationToken = default) =>
        Quickstats.GetQuickstatsAsync(cancellationToken);

    public Task<AccountList>
        GetQuickstatsSummaryAsync(CancellationToken cancellationToken = default) =>
        Quickstats.GetQuickstatsSummaryAsync(cancellationToken);
}