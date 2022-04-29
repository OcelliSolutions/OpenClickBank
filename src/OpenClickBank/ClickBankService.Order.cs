namespace OpenClickBank;

public partial class ClickBankService : IOrders2Client
{
    public Task IsActiveOrderOrSubscriptionAsync(string receipt, string? sku, CancellationToken cancellationToken = default) =>
        Orders.IsActiveOrderOrSubscriptionAsync(receipt, sku, cancellationToken);

    public Task<OrderList> ChangeOrderDateAsync(string receipt, DateTimeOffset changeDate, string? sku = null,
        CancellationToken cancellationToken = default) =>
        Orders.ChangeOrderDateAsync(receipt, changeDate, sku, cancellationToken);

    public Task<OrderList> GetOrderUpsellsAsync(string receipt,
        CancellationToken cancellationToken = default) =>
        Orders.GetOrderUpsellsAsync(receipt, cancellationToken);

    public Task<OrderList> GetOrderAsync(string receipt, string? sku = null,
        CancellationToken cancellationToken = default) =>
        Orders.GetOrderAsync(receipt, sku, cancellationToken);

    public Task<OrderList> GetOrdersAsync(int? page = null, DateTimeOffset? startDate = null,
        DateTimeOffset? endDate = null,
        OrderType? type = null, string? vendor = null, string? affiliate = null, string? lastName = null,
        string? item = null, string? email = null, string? tid = null, RoleAccount? role = null,
        string? postalCode = null,
        string? amount = null, CancellationToken cancellationToken = default) =>
        Orders.GetOrdersAsync(page, startDate, endDate, type, vendor, affiliate, lastName, item, email, tid, role,
            postalCode, amount, cancellationToken);

    public Task ReinstateOrderAsync(string receipt, string? sku = null,
        CancellationToken cancellationToken = default) =>
        Orders.ReinstateOrderAsync(receipt, sku, cancellationToken);

    public Task PauseOrderAsync(string receipt, DateTimeOffset restartDate, string? sku = null,
        CancellationToken cancellationToken = default) =>
        Orders.PauseOrderAsync(receipt, restartDate, sku, cancellationToken);

    public Task ExtendOrderAsync(string receipt, int numPeriods, string? sku = null,
        CancellationToken cancellationToken = default) =>
        Orders.ExtendOrderAsync(receipt, numPeriods, sku, cancellationToken);

    public Task ChangeOrderProductAsync(string receipt, string oldSku, string newSku, string? carryAffiliate = null,
        bool? applyProratedRefund = null, DateTimeOffset? nextRebillDate = null,
        CancellationToken cancellationToken = default) =>
        Orders.ChangeOrderProductAsync(receipt, oldSku, newSku, carryAffiliate, applyProratedRefund, nextRebillDate,
            cancellationToken);

    public Task ChangeOrderAddressAsync(string receipt, string address1, string city, string countryCode,
        string? firstName = null, string? lastName = null, string? address2 = null, string? county = null,
        string? province = null, string? postalCode = null,
        CancellationToken cancellationToken = default) =>
        Orders.ChangeOrderAddressAsync(receipt, address1, city, countryCode, firstName, lastName, address2, county,
            province, postalCode, cancellationToken);

    public Task<int> GetOrderCountAsync(DateTimeOffset? startDate = null, DateTimeOffset? endDate = null,
        OrderType? type = null, string? vendor = null, string? affiliate = null, string? lastName = null,
        string? item = null, string? email = null, string? tid = null, string? postalCode = null,
        RoleAccount? role = null, CancellationToken cancellationToken = default) =>
        Orders.GetOrderCountAsync(startDate, endDate, type, vendor, affiliate, lastName, item, email, tid, postalCode,
            role, cancellationToken);
}