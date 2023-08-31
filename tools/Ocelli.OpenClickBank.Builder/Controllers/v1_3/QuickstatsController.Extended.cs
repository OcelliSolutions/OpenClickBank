using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc cref="QuickstatsControllerBase"/>
[ApiController]
[SwaggerTag("The Quickstats API provides information about your account", "https://api.clickbank.com/rest/1.3/quickstats")]
public class QuickstatsController : QuickstatsControllerBase
{
    /// <inheritdoc cref="QuickstatsControllerBase.GetQuickstatCount"/>
    [Authorize]
    [Produces("text/plain")]
    //[Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    override public Task GetQuickstatCount(DateTime? startDate = null, DateTime? endDate = null, string? account = null) => throw new NotImplementedException();

    /// <inheritdoc cref="QuickstatsControllerBase.GetQuickstatAccounts"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(AccountList), StatusCodes.Status200OK)]
    override public Task GetQuickstatAccounts() => throw new NotImplementedException();

    /// <inheritdoc cref="QuickstatsControllerBase.GetQuickstats"/>
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_ORDER_READ, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(AccountList), StatusCodes.Status200OK)]
    override public Task GetQuickstats(DateTime? startDate = null, DateTime? endDate = null, string? account = null, [FromHeader] int? page = null) => throw new NotImplementedException();
}