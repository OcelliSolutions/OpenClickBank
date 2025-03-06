using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <inheritdoc cref="ImagesControllerBase" />
[ApiController]
[SwaggerTag("The Images API lists the images associated with an account", "https://api.clickbank.com/rest/1.3/images")]
public class ImagesController : ImagesControllerBase
{
    /// <inheritdoc cref="ImagesControllerBase.GetImages"/>
    [HttpGet, Route("1.3/images/list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ImageListResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ImageListResult), StatusCodes.Status206PartialContent)]
    public ActionResult GetImages(string site, ImageType? type, bool? approvedOnly, int? page = 1) => Ok();

    /// <inheritdoc cref="ImagesControllerBase.GetImages"/>
    [HttpGet, Route("1.3/images/list.ignore"), ApiExplorerSettings(IgnoreApi = true)]
    public override Task GetImages(string site, string? type = null, bool? approvedOnly = null, [FromHeader] int? page = null) => throw new NotImplementedException();

}