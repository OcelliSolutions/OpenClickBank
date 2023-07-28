using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ocelli.OpenClickBank.Builder.Controllers.v1_3;

/// <summary>
/// The ClickBank APIs include a debugging service
/// </summary>
[Route("rest")]
[ApiController]
public class DebugController : ControllerBase
{
    /// <summary>
    /// When you send a request to the debugging service, it returns the request context information including the security context information. This can be useful when correcting issues with the ClickBank APIs.
    /// </summary>
    [HttpGet, Route("1.3/debug")]
    [Authorize]
    [Produces("text/plain")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public ActionResult GetDebug() => Ok();
}