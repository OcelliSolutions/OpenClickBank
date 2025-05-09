using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc cref="Orders2ControllerBase" />
[ApiController]
[SwaggerTag("The Orders API lets you view order information and update some order parameters",
    "https://api.clickbank.com/rest/1.3/orders2")]
public class Orders2Controller : Orders2ControllerBase
{
    /// <inheritdoc cref="Orders2ControllerBase.ChangeAddressOrder" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_ORDER_WRITE })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task ChangeAddressOrder(string receipt, string address1, string city, string countryCode,
        string? firstName = null, string? lastName = null, string? address2 = null, string? county = null,
        string? province = null, string? postalCode = null) => throw new NotImplementedException();

    /// <inheritdoc cref="Orders2ControllerBase.ChangeDateOrder" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task ChangeDateOrder(string receipt, DateTime changeDate, string? sku = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="Orders2ControllerBase.ChangeProductOrder" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[]
    {
        ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_ORDER_WRITE, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS
    })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task ChangeProductOrder(string receipt, string oldSku, string newSku, bool? carryAffiliate = null,
        bool? applyProratedRefund = null, DateTime? nextRebillDate = null) => throw new NotImplementedException();

    /// <inheritdoc cref="Orders2ControllerBase.ExtendOrder" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task ExtendOrder(string receipt, int numPeriods, string? sku = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="Orders2ControllerBase.GetOrder" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    public override Task GetOrder(string receipt, string? sku = null) => throw new NotImplementedException();


    /// <inheritdoc cref="Orders2ControllerBase.GetOrderCount" />
    [HttpGet]
    [Route("1.3/orders2/count")]
    [Authorize]
    [Produces("text/plain")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public Task GetOrderCount(DateTime? startDate = null, DateTime? endDate = null, TransactionType? type = null,
        string? vendor = null, string? affiliate = null, string? lastName = null, string? item = null,
        string? email = null, string? tid = null, string? postalCode = null, RoleAccount? role = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="Orders2ControllerBase.GetOrderCount" />
    [HttpGet]
    [Route("1.3/orders2/count.ignore")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task GetOrderCount(DateTime? startDate = null, DateTime? endDate = null, string? type = null,
        string? vendor = null, string? affiliate = null, string? lastName = null, string? item = null,
        string? email = null, string? tid = null, string? postalCode = null, string? role = null) =>
        throw new NotImplementedException();


    /// <inheritdoc cref="Orders2ControllerBase.GetOrders" />
    [HttpGet]
    [Route("1.3/orders2/list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status206PartialContent)]
    public Task GetOrders(DateTime? startDate = null, DateTime? endDate = null, TransactionType? type = null,
        string? vendor = null, string? affiliate = null, string? lastName = null, string? item = null,
        string? email = null, string? tid = null, RoleAccount? role = null, string? postalCode = null,
        double? amount = null, [FromHeader] int? page = null) => throw new NotImplementedException();

    /// <inheritdoc cref="Orders2ControllerBase.GetOrders" />
    [HttpGet]
    [Route("1.3/orders2/list.ignore")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task GetOrders(DateTime? startDate = null, DateTime? endDate = null, string? type = null,
        string? vendor = null, string? affiliate = null, string? lastName = null, string? item = null,
        string? email = null, string? tid = null, string? role = null, string? postalCode = null, double? amount = null,
        int? page = null) => throw new NotImplementedException();


    /// <inheritdoc cref="Orders2ControllerBase.GetOrderStatus" />
    [Authorize]
    [Produces("application/xml", "application/json")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task GetOrderStatus(string receipt, string? sku = null) => throw new NotImplementedException();


    /// <inheritdoc cref="Orders2ControllerBase.GetOrderUpsells" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(OrderList), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task GetOrderUpsells(string receipt) => throw new NotImplementedException();

    /// <inheritdoc cref="Orders2ControllerBase.PauseOrder" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task PauseOrder(string receipt, DateTime restartDate, string? sku = null) =>
        throw new NotImplementedException();


    /// <inheritdoc cref="Orders2ControllerBase.ReinstateOrder" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.HAS_DEVELOPER_KEY, ApiPermission.API_SUBSCRIPTION_MODIFICATIONS })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override Task ReinstateOrder(string receipt, string? sku = null) => throw new NotImplementedException();
}