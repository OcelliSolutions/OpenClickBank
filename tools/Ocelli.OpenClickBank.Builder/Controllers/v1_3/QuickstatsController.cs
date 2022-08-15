using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

[Route("1.3/quickstats")]
[ApiController]
[SwaggerTag("The Quickstats API provides information about your account", "https://api.clickbank.com/rest/1.3/quickstats")]
public class QuickstatsController : ControllerBase
{
    [HttpGet("accounts")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.ApiOrderRead, ApiPermission.HasDeveloperKey })]
    [ProducesResponseType(typeof(AccountList), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Return a list of all account nicknames which the current api user has read access.")]
    public ActionResult GetAccounts() => Ok();

    [HttpGet("list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.ApiOrderRead, ApiPermission.HasDeveloperKey })]
    [ProducesResponseType(typeof(AccountList), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Return the quickstats for the api user, based on the search criteria. If no search conditions are set, it will return the quickstats for all the accounts for the API user for the last 45 days.")]
    public ActionResult GetQuickstats(
        [FromQuery, SwaggerParameter(Description = "The beginning date for the search (yyyy-mm-dd). Defaults to 45 days from today if not specified.")] DateTime startDate,
        [FromQuery, SwaggerParameter(Description = "The end date for the search (yyyy-mm-dd). Defaults to today if not specified.")] DateTime endDate,
        [FromQuery, SwaggerParameter(Description = "The nickName of the account. Defaults to all accounts if not specified.")] string account
        ) => Ok();

    [HttpGet("count")]
    [Authorize]
    [Produces("text/plain")]
    //[Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.ApiOrderRead, ApiPermission.HasDeveloperKey })]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Sums the quickstat sale, refund, and chargeback amounts based on the search criteria.", Description = "The count service sums the quickstat sale, refund and chargeback amounts based on the search criteria. If no search conditions are set, it will return the sum of the values for the last 45 days based on all the accounts linked to the API keys. The count service is similar to the list method except for the fact that it presents the user with one total of the dates specified the search criteria instead of listing each day's quickstat values individually. Note that the quickStatDate in the returned data will be null.")]
    public ActionResult GetQuickstatsCount(
        [FromQuery, SwaggerParameter(Description = "The beginning date for the search (yyyy-mm-dd). Defaults to 45 days from today if not specified.")] DateTime startDate,
        [FromQuery, SwaggerParameter(Description = "The end date for the search (yyyy-mm-dd). Defaults to today if not specified.")] DateTime endDate,
        [FromQuery, SwaggerParameter(Description = "The nickName of the account. Defaults to all accounts if not specified.")] string account
    ) => Ok();
}