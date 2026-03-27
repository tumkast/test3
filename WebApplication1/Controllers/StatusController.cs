using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(StatusResponse), StatusCodes.Status200OK)]
        public ActionResult<StatusResponse> Get()
        {
            return Ok(new StatusResponse("Running", DateTime.UtcNow));
        }
    }

    public record StatusResponse(string State, DateTime UtcTimestamp);
}
