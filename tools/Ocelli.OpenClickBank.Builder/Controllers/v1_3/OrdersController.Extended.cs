using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Models;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc />
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class OrdersController : OrdersControllerBase
{
    public override Task GetOrder(string receipt, string? sku = null) => throw new NotImplementedException();

    public override Task GetOrderStatus(string receipt, string? sku = null) => throw new NotImplementedException();
    public override Task Upsells(string receipt, string? sku = null) => throw new NotImplementedException();

    public override Task Reinstate(string receipt, string? sku = null) => throw new NotImplementedException();

    public override Task Pause(string receipt, DateTime restartDate, string? sku = null) => throw new NotImplementedException();

    public override Task Extend(string receipt, int numPeriods, string? sku = null) => throw new NotImplementedException();

    public override Task ChangeProduct(string receipt, string oldSku, string newSku, bool? carryAffiliate = null,
        bool? applyProratedRefundQuery = null, DateTime? nextRebillDate = null) =>
        throw new NotImplementedException();

    public override Task ChangeAddress(string receipt, string address1, string city, string countryCode, string? firstName = null,
        string? lastName = null, string? address2 = null, string? county = null, string? province = null,
        string? postalCode = null) =>
        throw new NotImplementedException();

    public override Task Count(DateTime? startDate = null, DateTime? endDate = null, string? type = null, string? vendor = null,
        string? affiliate = null, string? lastName = null, string? email = null, string? tid = null, string? role = null) =>
        throw new NotImplementedException();

    public override Task List(DateTime? startDate = null, DateTime? endDate = null, string? type = null, string? vendor = null,
        string? affiliate = null, string? lastName = null, string? item = null, string? email = null, string? tid = null,
        string? role = null, string? postalCode = null, string? amount = null, int? page = null) =>
        throw new NotImplementedException();
}