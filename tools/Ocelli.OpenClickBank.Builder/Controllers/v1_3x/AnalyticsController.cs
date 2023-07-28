using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

[Route("1.3/analytics")]
[ApiController]
[SwaggerTag("The Analytics API provides account and subscription analytics information", "https://api.clickbank.com/rest/1.3/analytics")]
public class AnalyticsManualController : ControllerBase
{
    [HttpGet("status")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(AnalyticStatus), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Return the status & last update time of the API.")]
    public ActionResult GetStatus() => Ok();

    [HttpGet("{role}/subscription/details/compthirty")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(SubscriptionDetailResult), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Returns a list of subscriptions completing in the next 30 days.")]
    public ActionResult GetSubscriptionDetailsCompletingIn30Days(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, FromQuery, SwaggerParameter(Description = "The account nickname/site.")] string account,
        [FromQuery, SwaggerParameter(Description = "Customer details are only available to vendors.")] SubscriptionDetailRowOrderBy? orderBy,
        [FromQuery, SwaggerParameter(Description = "The order in which the sorted results are returned")] SortDirection? sortDirection) => Ok();

    [HttpGet("{role}/subscription/details/compsixty")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(SubscriptionDetailResult), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Returns a list of subscriptions completing in the next 60 days.")]
    public ActionResult GetSubscriptionDetailsCompletingIn60Days(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, FromQuery, SwaggerParameter(Description = "The account nickname/site.")] string account,
        [FromQuery, SwaggerParameter(Description = "Customer details are only available to vendors.")] SubscriptionDetailRowOrderBy? orderBy,
        [FromQuery, SwaggerParameter(Description = "The order in which the sorted results are returned")] SortDirection? sortDirection) => Ok();

    [HttpGet("{role}/subscription/details/cancelthirty")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(SubscriptionDetailResult), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Returns a list of subscriptions canceled in the last 30 days.")]
    public ActionResult GetSubscriptionDetailsCanceledLast30Days(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, FromQuery, SwaggerParameter(Description = "The account nickname/site.")] string account,
        [FromQuery, SwaggerParameter(Description = "Customer details are only available to vendors.")] SubscriptionDetailRowOrderBy? orderBy,
        [FromQuery, SwaggerParameter(Description = "The order in which the sorted results are returned")] SortDirection? sortDirection) => Ok();

    [HttpGet("{role}/subscription/details/cancelsixty")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(SubscriptionDetailResult), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Returns a list of subscriptions canceled in the last 60 days.")]
    public ActionResult GetSubscriptionDetailsCanceledLast60Days(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, FromQuery, SwaggerParameter(Description = "The account nickname/site.")] string account,
        [FromQuery, SwaggerParameter(Description = "Customer details are only available to vendors.")] SubscriptionDetailRowOrderBy? orderBy,
        [FromQuery, SwaggerParameter(Description = "The order in which the sorted results are returned")] SortDirection? sortDirection) => Ok();

    [HttpGet("{role}/subscription/details/startdate")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(SubscriptionDetailResult), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Returns a list of subscriptions where the subscription start date is between (inclusive) the startDate and endDate parameters.")]
    public ActionResult GetSubscriptionDetailsByStartDate(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, FromQuery, SwaggerParameter(Description = "The account nickname/site.")] string account,
        [FromQuery, SwaggerParameter(Description = "Customer details are only available to vendors.")] SubscriptionDetailRowOrderBy? orderBy,
        [FromQuery, SwaggerParameter(Description = "The order in which the sorted results are returned")] SortDirection? sortDirection,
        [Required, FromQuery, SwaggerParameter(Description = "The earliest subscription start date the result list will contain. Date Format: yyyy-MM-dd.")] DateTime? startDate,
        [Required, FromQuery, SwaggerParameter(Description = "The latest subscription start date the result list will contain. Date Format: yyyy-MM-dd.")] DateTime? endDate) => Ok();

    [HttpGet("{role}/subscription/details/canceldate")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(SubscriptionDetailResult), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Returns a list of subscriptions where the subscription canceled date is between (inclusive) the startDate and endDate parameters.")]
    public ActionResult GetSubscriptionDetailsByCancelDate(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, FromQuery, SwaggerParameter(Description = "The account nickname/site.")] string account,
        [FromQuery, SwaggerParameter(Description = "Customer details are only available to vendors.")] SubscriptionDetailRowOrderBy? orderBy,
        [FromQuery, SwaggerParameter(Description = "The order in which the sorted results are returned")] SortDirection? sortDirection,
        [Required, FromQuery, SwaggerParameter(Description = "The earliest subscription cancellation date the result list will contain. Date Format: yyyy-MM-dd.")] DateTime? startDate,
        [Required, FromQuery, SwaggerParameter(Description = "The latest subscription cancellation date the result list will contain. Date Format: yyyy-MM-dd.")] DateTime? endDate) => Ok();

    [HttpGet("{role}/subscription/details/nextpmtdate")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(SubscriptionDetailResult), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Returns a list of subscriptions where the next payment date is between (inclusive) the startDate and endDate parameters.")]
    public ActionResult GetSubscriptionDetailsByNextPaymentDate(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, FromQuery, SwaggerParameter(Description = "The account nickname/site.")] string account,
        [FromQuery, SwaggerParameter(Description = "Customer details are only available to vendors.")] SubscriptionDetailRowOrderBy? orderBy,
        [FromQuery, SwaggerParameter(Description = "The order in which the sorted results are returned")] SortDirection? sortDirection,
        [Required, FromQuery, SwaggerParameter(Description = "The earliest next subscription payment date the result list will contain. Date Format: yyyy-MM-dd.")] DateTime? startDate,
        [Required, FromQuery, SwaggerParameter(Description = "The latest next subscription payment date the result list will contain. Date Format: yyyy-MM-dd.")] DateTime? endDate) => Ok();

    [HttpGet("{role}/subscription/details/status")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(SubscriptionDetailResult), StatusCodes.Status200OK)]
    //[SwaggerOperation(Summary = @"Returns a list of subscriptions by the status used in the status parameter.")]
    public ActionResult GetSubscriptionDetailsByStatusDate(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, FromQuery, SwaggerParameter(Description = "The account nickname/site.")] string account,
        [FromQuery, SwaggerParameter(Description = "Customer details are only available to vendors.")] SubscriptionDetailRowOrderBy? orderBy,
        [FromQuery, SwaggerParameter(Description = "The order in which the sorted results are returned")] SortDirection? sortDirection,
        [Required, FromQuery, SwaggerParameter(Description = "The subscription status.")] SubscriptionStatus status) => Ok();

    [HttpGet("{role}/subscription/details")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(SubscriptionDetailResult), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Returns a list of subscriptions details.")]
    public ActionResult GetSubscriptionDetails(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, FromQuery, SwaggerParameter(Description = "The account nickname/site.")] string account,
        [FromQuery, SwaggerParameter(Description = "Customer details are only available to vendors.")] SubscriptionDetailRowOrderBy? orderBy,
        [FromQuery, SwaggerParameter(Description = "The order in which the sorted results are returned")] SortDirection? sortDirection) => Ok();

    [HttpGet("{role}/subscription/trends")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(SubscriptionTrendsData), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(SubscriptionTrendsData), StatusCodes.Status206PartialContent)]
    [SwaggerOperation(Summary = @"Returns statistical summations of data for subscriptions.")]
    public ActionResult GetSubscriptionTrends(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, FromQuery, SwaggerParameter(Description = "The account nickname/site.")] string account,
        [FromQuery, SwaggerParameter(Description = "You may group by business date by passing DATE as the value.")] string? groupBy,
        [FromQuery, SwaggerParameter(Description = "The product id to report on, multiple parameter/value pairs may be passed.")] int? productId,
        [Required, FromQuery, SwaggerParameter(Description = "The start date (inclusive) of the time frame to report on - format is yyyy-MM-dd.")] DateTime? startDate,
        [Required, FromQuery, SwaggerParameter(Description = "The end date (inclusive) of the time frame to report on - format is yyyy-MM-dd.")] DateTime? endDate,
        [FromHeader, SwaggerParameter(Description = "The page number of the results (default is page 1).")] int? page = 1) => Ok();

    [HttpGet("{role}/{dimension}"), Obsolete("This endpoint is no longer available")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(AnalyticsResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(AnalyticsResult), StatusCodes.Status206PartialContent)]
    [SwaggerOperation(Summary = @"Returns statistical data for a given role and dimension.")]
    public ActionResult GetStatisticsByRoleAndDimension(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, SwaggerParameter(Description = @"PRODUCT_SKU – Only available if role = VENDOR
VENDOR_PRODUCT_SKU – Only available if role = AFFILIATE")] Dimension dimension,
        [Required, FromQuery, SwaggerParameter(Description = "Account/site to query for.")] string account,
        [FromQuery, SwaggerParameter(Description = "The start date of the time frame to report on - format is yyyy-MM-dd. Defaults to the previous day.")] DateTime? startDate,
        [FromQuery, SwaggerParameter(Description = "The end date of the time frame to report on - format is yyyy-MM-dd. Defaults to the current day.")] DateTime? endDate,
        [FromQuery, SwaggerParameter(Description = "This parameter limits the results returned to ones with a matching dimension id. This value is case sensitive.")] Dimension? dimensionFilter,
        [FromQuery, SwaggerParameter(Description = "This optional parameter specifies the data fields to return. Multiple select parameters may be passed to select multiple values. If this parameter is absent all values will be returned.")] DimensionColumn[]? select,
        [FromQuery, SwaggerParameter(Description = "This optional parameter specifies which data field the results should be ordered by.")] DimensionColumn? orderBy,
        [FromQuery, SwaggerParameter(Description = "When an order by is included this may be specified with a value of true to sort ascending instead of descending")] bool? sortAscending,
        [FromHeader, SwaggerParameter(Description = "The page number of the results (default is page 1).")] int? page = 1) => Ok();

    [HttpGet("{role}/{dimension}/summary"), Obsolete("This endpoint is no longer available")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ANALYTICS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(AnalyticsResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(AnalyticsResult), StatusCodes.Status206PartialContent)]
    [SwaggerOperation(Summary = @"Returns summary statistical data for a given role, dimension, and summary type.")]
    public ActionResult GetStatisticsByRoleAndDimensionSummary(
        [Required, SwaggerParameter(Description = "A valid role")] RoleAccount role,
        [Required, SwaggerParameter(Description = @"PRODUCT_SKU – Only available if role = VENDOR
VENDOR_PRODUCT_SKU – Only available if role = AFFILIATE")] Dimension dimension,
        [Required, FromQuery, SwaggerParameter(Description = "Account/site to query for.")] string account,
        [Required, FromQuery, SwaggerParameter(Description = @"This parameter specifies which type of summary data is desired.
VENDOR_ONLY - this shows summary information for only the selected account
AFFILIATE_ONLY - this shows summary information which excludes the selected account")] SummaryType summaryType,
        [FromQuery, SwaggerParameter(Description = "The start date of the time frame to report on - format is yyyy-MM-dd. Defaults to the previous day.")] DateTime? startDate,
        [FromQuery, SwaggerParameter(Description = "The end date of the time frame to report on - format is yyyy-MM-dd. Defaults to the current day.")] DateTime? endDate,
        [FromQuery, SwaggerParameter(Description = "This parameter limits the results returned to ones with a matching dimension id. This value is case sensitive.")] Dimension? dimensionFilter,
        [FromQuery, SwaggerParameter(Description = "This optional parameter specifies the data fields to return. Multiple select parameters may be passed to select multiple values. If this parameter is absent all values will be returned.")] DimensionColumn[]? select,
        [FromQuery, SwaggerParameter(Description = "This optional parameter specifies which data field the results should be ordered by.")] DimensionColumn? orderBy,
        [FromQuery, SwaggerParameter(Description = "When an order by is included this may be specified with a value of true to sort ascending instead of descending")] bool? sortAscending,
        [FromHeader, SwaggerParameter(Description = "The page number of the results (default is page 1).")] int? page = 1) => Ok();
}
