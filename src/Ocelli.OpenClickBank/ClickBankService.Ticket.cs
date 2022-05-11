namespace Ocelli.OpenClickBank;

public partial class ClickBankService : ITicketClient
{
    public Task<TicketData?> CreateTicketAsync(string receipt, QueryTicketType type, string reason, string? sku = null,
        string? comment = null, RefundType? refundType = null, double? refundAmount = null,
        bool? retainSubscription = null, CancellationToken cancellationToken = default) =>
        Tickets.CreateTicketAsync(receipt, type, reason, sku, comment, refundType, refundAmount, retainSubscription,
            cancellationToken);

    public Task<IDictionary<string, object>?> GetTicketRefundAmountsAsync(string receipt, RefundType refundType,
        string? sku = null, double? refundAmount = null, CancellationToken cancellationToken = default) =>
        Tickets.GetTicketRefundAmountsAsync(receipt, refundType, sku, refundAmount, cancellationToken);

    public Task<TicketData?>
        GetTicketAsync(int id, CancellationToken cancellationToken = default) =>
        Tickets.GetTicketAsync(id, cancellationToken);

    public Task<TicketData?> UpdateTicketAsync(int id, TicketAction? action = null, string? comment = null,
        QueryTicketType? type = null,
        CancellationToken cancellationToken = default) =>
        Tickets.UpdateTicketAsync(id, action, comment, type, cancellationToken);

    public Task<ShippingNoticeData?> AcceptReturnFromCustomerAsync(int id,
        CancellationToken cancellationToken = default) =>
        Tickets.AcceptReturnFromCustomerAsync(id, cancellationToken);

    public Task<TicketList?> GetTicketsAsync(QueryTicketType? type = null, TicketStatus? status = null,
        string? receipt = null, DateTimeOffset? createDateFrom = null, DateTimeOffset? createDateTo = null,
        DateTimeOffset? updateDateFrom = null, DateTimeOffset? updateDateTo = null, DateTimeOffset? closeDateFrom = null,
        DateTimeOffset? closeDateTo = null, int? page = 1, CancellationToken cancellationToken = default) =>
        Tickets.GetTicketsAsync(type, status, receipt, createDateFrom, createDateTo, updateDateFrom, updateDateTo,
            closeDateFrom, closeDateTo, page, cancellationToken);

    public Task<int> GetTicketCountAsync(QueryTicketType? type = null, TicketStatus? status = null,
        string? receipt = null, CancellationToken cancellationToken = default) =>
        Tickets.GetTicketCountAsync(type, status, receipt, cancellationToken);
}