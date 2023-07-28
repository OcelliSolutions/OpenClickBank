using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc />
[ApiController]
public class Orders2Controller : Orders2ControllerBase
{
    /// <inheritdoc cref="Orders2ControllerBase.Reinstate"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task Reinstate(string receipt, string? sku = null) => throw new NotImplementedException();

    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task Pause(string receipt, DateTime restartDate, string? sku = null) => throw new NotImplementedException();

    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public override Task Extend(string receipt, int numPeriods, string? sku = null) => throw new NotImplementedException();

    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_ORDER_WRITE, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task ChangeProduct(string newSku, string oldSku, string receipt, bool? applyProratedRefund = null,
        bool? carryAffiliate = null, DateTime? nextRebillDate = null) =>
        throw new NotImplementedException();

    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_ORDER_WRITE })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task ChangeAddress(string address1, string city, string countryCode, string receipt, string? address2 = null,
        string? county = null, string? firstName = null, string? lastName = null, string? postalCode = null,
        string? province = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="Orders2ControllerBase.Count"/>
    [HttpGet, Route("1.3/orders2/count")]
    [Authorize]
    [Produces("text/plain")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public Task Count(DateTime? startDate = null, DateTime? endDate = null, string? type = null, string? vendor = null,
        string? affiliate = null, string? lastName = null, string? item = null, string? email = null, string? tid = null,
        string? postalCode = null, RoleAccount? role = null) =>
        throw new NotImplementedException();

    [HttpGet, Route("1.3/orders2/count.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    public override Task Count(DateTime? startDate = null, DateTime? endDate = null, string? type = null, string? vendor = null,
        string? affiliate = null, string? lastName = null, string? item = null, string? email = null, string? tid = null,
        string? postalCode = null, string? role = null) =>
        throw new NotImplementedException();

    [HttpGet, Route("1.3/orders2/list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status206PartialContent)]
    public Task List(DateTime? startDate = null, DateTime? endDate = null, string? type = null, string? vendor = null,
        string? affiliate = null, string? lastName = null, string? item = null, string? email = null, string? tid = null,
        RoleAccount? role = null, string? postalCode = null, string? amount = null, int? page = null) =>
        throw new NotImplementedException();

    [HttpGet, Route("1.3/orders2/list.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    public override Task List(DateTime? startDate = null, DateTime? endDate = null, string? type = null, string? vendor = null,
        string? affiliate = null, string? lastName = null, string? item = null, string? email = null, string? tid = null,
        string? role = null, string? postalCode = null, string? amount = null, int? page = null) =>
        throw new NotImplementedException();
    
    public override Task GetOrderStatus(string receipt, string? sku = null) => throw new NotImplementedException();

    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    public override Task GetOrder(string receipt, string? sku = null) => throw new NotImplementedException();

    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task Upsells(string receipt, DateTime changeDate, string? sku = null) => throw new NotImplementedException();

    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task ChangeDate(string receipt, DateTime changeDate, string? sku = null) => throw new NotImplementedException();
}