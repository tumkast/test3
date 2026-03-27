using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(VersionInfo), StatusCodes.Status200OK)]
        public ActionResult<VersionInfo> Get()
        {
            return Ok(new VersionInfo("1.0.0", Environment.Version.ToString()));
        }
    }

    public record VersionInfo(string ApiVersion, string RuntimeVersion);
}
