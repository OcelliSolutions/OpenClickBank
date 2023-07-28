using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc />
[ApiController]
[SwaggerTag("The Images API lists the images associated with an account", "https://api.clickbank.com/rest/1.3/images")]
public class ImagesController : ImagesControllerBase
{
    /// <inheritdoc cref="ImagesControllerBase.List"/>
    [HttpGet, Route("1.3/images/list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ImageListResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ImageListResult), StatusCodes.Status206PartialContent)]
    public ActionResult List(string site, ImageType? type, bool? approvedOnly, int? page = 1) => Ok();
    
    [HttpGet, Route("1.3/images/list.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    public override Task List(string site, string? type = null, bool? approvedOnly = null, int? page = null) => throw new NotImplementedException();
}