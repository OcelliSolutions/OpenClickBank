using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc cref="ShippingControllerBase" />
[ApiController]
[Obsolete("Use shipping API")]
[ApiExplorerSettings(IgnoreApi = true)]
[SwaggerTag("The Shipping API provides shipping information for physical good orders by receipt or time parameters. This also contains the Ship Notice API.", "https://api.clickbank.com/rest/1.3/shipping")]
public class ShippingController : ShippingControllerBase
{

    /// <inheritdoc cref="ShippingControllerBase.GetShippingCount" />
    [HttpGet, Route("1.3/shipping/count")]
    [Authorize]
    [Produces("application/json", "application/xml")] //This is not a typo, passing in `plain/text` causes an 406 error.
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public Task GetShippingCount(ShippingStatus? status = null, int? days = null, DateTime? startDate = null, DateTime? endDate = null,
        string? receipt = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="ShippingControllerBase.GetShippingCount" />
    [HttpGet, Route("1.3/shipping/count.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    override public Task GetShippingCount(string? status = null, int? days = null, DateTime? startDate = null, DateTime? endDate = null,
        string? receipt = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="ShippingControllerBase.GetShippings" />
    [HttpGet, Route("1.3/shipping/list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ShippingList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ShippingList), StatusCodes.Status206PartialContent)]
    public Task GetShippings(ShippingStatus? status = null, int? days = null, DateTime? startDate = null, DateTime? endDate = null,
        string? receipt = null, int? page = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="ShippingControllerBase.GetShippings" />
    [HttpGet, Route("1.3/shipping/list.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    override public Task GetShippings(string? status = null, int? days = null, DateTime? startDate = null, DateTime? endDate = null,
        string? receipt = null, int? page = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="ShippingControllerBase.CreateShipNotice" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.API_ORDER_WRITE, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ShippingNoticeData), StatusCodes.Status200OK)]
    override public Task CreateShipNotice(string receipt, DateTime date, string carrier, string? tracking = null, string? comments = null,
        string? item = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="ShippingControllerBase.GetShipNotice" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ShippingNoticeList), StatusCodes.Status200OK)]
    override public Task GetShipNotice(string receipt) => throw new NotImplementedException();
}