using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplication1.CherryLab;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/cherry-lab")]
    public class CherryLabController : ControllerBase
    {
        private readonly CherryLabSettings _settings;

        public CherryLabController(IOptions<CherryLabSettings> options)
        {
            _settings = options.Value;
        }

        [HttpGet("alpha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<object> Alpha()
        {
            return Ok(new { branch = "A", tag = _settings.AlphaTag });
        }
    }
}
