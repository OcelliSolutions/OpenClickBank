using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

[Route("1.3/shipping2")]
[ApiController]
[SwaggerTag("The Shipping API provides shipping information for physical good orders by receipt or time parameters. This also contains the Ship Notice API.", "https://api.clickbank.com/rest/1.3/shipping2")]
public class Shipping2Controller : ControllerBase
{
    [HttpGet("list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ShippingList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ShippingList), StatusCodes.Status206PartialContent)]
    [SwaggerOperation(Summary = @"List physical goods orders matching the shipping criteria. Only the first 100 orders will be returned. This method supports pagination, so if the second page of the next 100 items is required a request header 'Page' with value 2 will return them.
This method will return 200 if all the orders have been obtained, or a 206 [Partial Return] if there are more results available. An important point to note is that this method will only return shippable orders matching search criteria, so if a user wants to get all orders, they will need to use the Orders Service API.")]
    public ActionResult GetShipping(
        [FromQuery, SwaggerParameter(Description = "Can be 'shipped', 'notshipped' or 'all' - to find related orders.")] ShippingStatus? status,
        [FromQuery, Range(0, int.MaxValue), SwaggerParameter(Description = "Return orders within the last n days. If start and end date are specified, they will take precedence over this value. If neither days, startDate or endDate is specified, it will default to last 30 days or orders.")] int? days,
        [FromQuery, SwaggerParameter(Description = "Instead of using the days parameter, a user can specify a date range (yyyy-mm-dd). This is the start date.")] DateTime? startDate,
        [FromQuery, SwaggerParameter(Description = "Instead of using the days parameter, a user can specify a date range (yyyy-mm-dd). This is the endDate.")] DateTime? endDate,
        [FromQuery, SwaggerParameter(Description = "Search the physical good order by receipt. If this parameter is specified, the other search parameters will be ignored.")] string? receipt,
        [FromHeader, SwaggerParameter(Description = "Page Number. Results only return 100 records at a time.")] int? page = 1) => Ok();

    [HttpGet("count")]
    [Authorize]
    [Produces("application/json", "application/xml")] //This is not a typo, passing in `plain/text` causes an 406 error.
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY})]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Returns a count of physical goods orders matching the shipping criteria.
An important point to note is that this method will only return shippable orders matching search criteria, so if a user wants to get all orders, they will need to use the Orders Service API.")]
    public ActionResult GetShippingCount(
        [FromQuery, SwaggerParameter(Description = "Can be 'shipped', 'notshipped' or 'all' - to find related orders.")] ShippingStatus? status,
        [FromQuery, SwaggerParameter(Description = "Return orders within the last n days. If start and end date are specified, they will take precedence over this value. If neither days, startDate or endDate is specified, it will default to last 30 days or orders.")] int? days,
        [FromQuery, SwaggerParameter(Description = "Instead of using the days parameter, a user can specify a date range (yyyy-mm-dd). This is the start date.")] DateTime? startDate,
        [FromQuery, SwaggerParameter(Description = "Instead of using the days parameter, a user can specify a date range (yyyy-mm-dd). This is the endDate.")] DateTime? endDate,
        [FromQuery, SwaggerParameter(Description = "Search the physical good order by receipt. If this parameter is specified, the other search parameters will be ignored.")] string? receipt) => Ok();

    [HttpGet("shipnotice/{receipt}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ShippingNoticeData), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Returns the ship notices for the given transaction.")]
    public ActionResult GetShippingNotice(
        [Required, SwaggerParameter(Description = "Receipt ID")] string receipt) => Ok();

    [HttpPost("shipnotice/{receipt}")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.API_ORDER_WRITE, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ShippingNoticeData), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Creates a shipping notice for the given transaction.")]
    public ActionResult CreateShippingNotice(
        [Required, SwaggerParameter(Description = "Receipt ID")] string receipt,
        [Required, FromQuery, SwaggerParameter("The shipping date (yyyy-mm-dd). This date cannot be earlier than the date of purchase or later than the current date. The date is calculated in Pacific Standard Time (PST). Thus, in order to use the current date, please ensure that it is also the current date according to PST.")] DateTime date,
        [Required, FromQuery, SwaggerParameter("The shipping carrier.")] string carrier,
        [Required, FromQuery, SwaggerParameter("Indicates that the receipt is part of an order to be shipped altogether, for which the remaining shipping notices should be automatically generated.")] bool? fillOrder,
        [FromQuery, SwaggerParameter("The sku/itemNo of the line item. This parameter is required if the transaction includes multiple physical items.")] string? item,
        [FromQuery, SwaggerParameter("The tracking id.")] string? tracking,
        [FromQuery, SwaggerParameter("The comments  associated with the notice.")] string? comments) => Ok();
}
