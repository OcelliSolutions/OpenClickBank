namespace Ocelli.OpenClickBank;

public partial class ClickBankService : IShipping2Client
{
    public Task<ShippingList> GetShippingAsync(ShippingStatus? status = null, int? days = null,
        DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, string? receipt = null,
        int? page = 1, CancellationToken cancellationToken = default) =>
        Shipping.GetShippingAsync(status, days, startDate, endDate, receipt, page, cancellationToken);

    public Task<int> GetShippingCountAsync(ShippingStatus? status = null, int? days = null,
        DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, string? receipt = null,
        CancellationToken cancellationToken = default) =>
        Shipping.GetShippingCountAsync(status, days, startDate, endDate, receipt, cancellationToken);

    public Task<ShippingNoticeData> GetShippingNoticeAsync(string receipt,
        CancellationToken cancellationToken = default) =>
        Shipping.GetShippingNoticeAsync(receipt, cancellationToken);

    public Task<ShippingNoticeData> CreateShippingNoticeAsync(string receipt, DateTimeOffset date, string carrier,
        string tracking, string comments, string item, string fillOrder,
        CancellationToken cancellationToken = default) =>
        Shipping.CreateShippingNoticeAsync(receipt, date, carrier, tracking, comments, item, fillOrder,
            cancellationToken);
}