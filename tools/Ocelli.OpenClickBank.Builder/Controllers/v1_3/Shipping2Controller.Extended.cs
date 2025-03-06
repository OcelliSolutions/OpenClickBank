using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc cref="Shipping2ControllerBase" />
[ApiController]
[SwaggerTag("The Shipping API provides shipping information for physical good orders by receipt or time parameters. This also contains the Ship Notice API.", "https://api.clickbank.com/rest/1.3/shipping2")]
public class Shipping2Controller : Shipping2ControllerBase
{

    /// <inheritdoc cref="Shipping2ControllerBase.GetShippingCount" />
    [HttpGet, Route("1.3/shipping2/count")]
    [Authorize]
    [Produces("application/json", "application/xml")] //This is not a typo, passing in `plain/text` causes an 406 error.
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public Task GetShippingCount(ShippingStatus? status = null, int? days = null, DateTime? startDate = null, DateTime? endDate = null,
        string? receipt = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="Shipping2ControllerBase.GetShippingCount" />
    [HttpGet, Route("1.3/shipping2/count.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    public override Task GetShippingCount(string? status = null, int? days = null, DateTime? startDate = null, DateTime? endDate = null,
        string? receipt = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="Shipping2ControllerBase.GetShippings" />
    [HttpGet, Route("1.3/shipping2/list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ShippingList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ShippingList), StatusCodes.Status206PartialContent)]
    public Task GetShippings(ShippingStatus? status = null, int? days = null, DateTime? startDate = null, DateTime? endDate = null,
        string? receipt = null, [FromHeader] int? page = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="Shipping2ControllerBase.GetShippings" />
    [HttpGet, Route("1.3/shipping2/list.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    public override Task GetShippings(string? status = null, int? days = null, DateTime? startDate = null, DateTime? endDate = null,
        string? receipt = null, [FromHeader] int? page = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="Shipping2ControllerBase.CreateShipNotice" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.API_ORDER_WRITE, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ShippingNoticeData), StatusCodes.Status200OK)]
    public override Task CreateShipNotice(string receipt, DateTime date, string carrier, string? tracking = null, string? comments = null,
        string? item = null, bool? fillOrder = null) =>
        throw new NotImplementedException();

    /// <inheritdoc cref="Shipping2ControllerBase.GetShipNotice" />
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ShippingNoticeList), StatusCodes.Status200OK)]
    public override Task GetShipNotice(string receipt) => throw new NotImplementedException();
}