using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

[Route("1.3/debug")]
[ApiController]
public class DebugController : ControllerBase
{
    [HttpGet]
    [Authorize]
    [Produces("text/plain")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "When you send a request to the debugging service, it returns the request context information including the security context information. This can be useful when correcting issues with the ClickBank APIs.")]
    public ActionResult GetDebug() => Ok();
}