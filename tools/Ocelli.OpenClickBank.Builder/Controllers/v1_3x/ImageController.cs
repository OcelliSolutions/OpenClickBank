using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelli.OpenClickBank.Builder.Data;
using Ocelli.OpenClickBank.Builder.Filters;
using Ocelli.OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;
[Route("1.3/images")]
[ApiController]
[SwaggerTag("The Images API lists the images associated with an account", "https://api.clickbank.com/rest/1.3/images")]
public class ImageManualController : ControllerBase
{
    [HttpGet("list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.API_PRODUCTS_CLIENT, ApiPermission.HAS_DEVELOPER_KEY })]
    [ProducesResponseType(typeof(ImageListResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ImageListResult), StatusCodes.Status206PartialContent)]
    [SwaggerOperation(Summary = @"Lists images associated with a site.")]
    public ActionResult GetImages(
        [Required, FromQuery, SwaggerParameter(Description = "The site owning the images.")] string site,
        [FromQuery, SwaggerParameter(Description = "The image type.")] ImageType? type,
        [FromQuery, SwaggerParameter(Description = "If true only approved images [Default = true].")] bool? approvedOnly,
        [FromHeader, SwaggerParameter(Description = "Page Number. Results only return 100 records at a time.")] int? page = 1) => Ok();
}
