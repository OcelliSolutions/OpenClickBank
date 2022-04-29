using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenClickBank.Builder.Data;
using OpenClickBank.Builder.Filters;
using OpenClickBank.Builder.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenClickBank.Builder.Controllers.v1_3;
[Route("1.3/images")]
[ApiController]
[SwaggerTag("The Images API lists the images associated with an account", "https://api.clickbank.com/rest/1.3/images")]
public class ImageController : ControllerBase
{
    [HttpGet("list")]
    [Authorize]
    [Produces("application/json", "application/xml")]
    [ApiAuthorizationFilter(new[] { ApiPermission.ApiProductsClient, ApiPermission.HasDeveloperKey })]
    [ProducesResponseType(typeof(ImageListResult), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = @"Lists images associated with a site.")]
    public ActionResult GetImages(
        [Required, FromQuery, SwaggerParameter(Description = "The site owning the images.")] string site,
        [FromQuery, SwaggerParameter(Description = "The image type.")] ImageType? type,
        [FromQuery, SwaggerParameter(Description = "If true only approved images [Default = true].")] bool? approvedOnly) => Ok();
}
