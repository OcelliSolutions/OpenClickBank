using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc cref="OrdersControllerBase"/>
[ApiController]
[Obsolete("Use orders API")]
[ApiExplorerSettings(IgnoreApi = true)]
[SwaggerTag("The Orders API lets you view order information and update some order parameters", "https://api.clickbank.com/rest/1.3/orders")]
public class OrdersController : OrdersControllerBase
{
    /// <inheritdoc cref="OrdersControllerBase.ReinstateOrder"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    override public Task ReinstateOrder(string receipt, string? sku = null) => throw new NotImplementedException();

    /// <inheritdoc cref="OrdersControllerBase.PauseOrder"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    override public Task PauseOrder(string receipt, DateTime restartDate, string? sku = null) => throw new NotImplementedException();

    /// <inheritdoc cref="OrdersControllerBase.ExtendOrder"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    override public Task ExtendOrder(string receipt, int numPeriods, string? sku = null) => throw new NotImplementedException();

    /// <inheritdoc cref="OrdersControllerBase.ChangeProductOrder"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_ORDER_WRITE, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    override public Task ChangeProductOrder(string receipt, string oldSku, string newSku, bool? carryAffiliate = null,
        bool? applyProratedRefundQuery = null, DateTime? nextRebillDate = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="OrdersControllerBase.ChangeAddressOrder"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_ORDER_WRITE })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    override public Task ChangeAddressOrder(string receipt, string address1, string city, string countryCode, string? firstName = null,
        string? lastName = null, string? address2 = null, string? county = null, string? province = null,
        string? postalCode = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="OrdersControllerBase.GetOrderCount"/>
    [HttpGet, Route("1.3/orders/count")]
    [Authorize]
    [Produces("text/plain")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public Task GetOrderCount(DateTime? startDate = null, DateTime? endDate = null, TransactionType? type = null, string? vendor = null,
        string? affiliate = null, string? lastName = null, string? email = null, string? tid = null, RoleAccount? role = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="OrdersControllerBase.GetOrderCount"/>
    [HttpGet, Route("1.3/orders/count.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    override public Task GetOrderCount(DateTime? startDate = null, DateTime? endDate = null, string? type = null, string? vendor = null,
        string? affiliate = null, string? lastName = null, string? email = null, string? tid = null, string? role = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="OrdersControllerBase.GetOrders"/>
    [HttpGet, Route("1.3/orders/list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status206PartialContent)]
    public Task GetOrders(DateTime? startDate = null, DateTime? endDate = null, TransactionType? type = null, string? vendor = null,
        string? affiliate = null, string? lastName = null, string? item = null, string? email = null, string? tid = null,
        RoleAccount? role = null, string? postalCode = null, double? amount = null, int? page = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="OrdersControllerBase.GetOrders"/>
    [HttpGet, Route("1.3/orders/list.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    override public Task GetOrders(DateTime? startDate = null, DateTime? endDate = null, string? type = null, string? vendor = null,
        string? affiliate = null, string? lastName = null, string? item = null, string? email = null, string? tid = null,
        string? role = null, string? postalCode = null, double? amount = null, int? page = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="OrdersControllerBase.GetOrderStatus"/>
    [Authorize]
    [Produces("application/xml", "application/json")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task GetOrderStatus(string receipt, string? sku = null) => throw new NotImplementedException();

    /// <inheritdoc cref="OrdersControllerBase.GetOrder"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    public override Task GetOrder(string receipt, string? sku = null) => throw new NotImplementedException();

    /// <inheritdoc cref="OrdersControllerBase.GetOrderUpsells"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    override public Task GetOrderUpsells(string receipt) => throw new NotImplementedException();
}