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
        private readonly CherryLabFormatter _formatter;

        public CherryLabController(IOptions<CherryLabSettings> options, CherryLabFormatter formatter)
        {
            _settings = options.Value;
            _formatter = formatter;
        }

        [HttpGet("alpha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<object> Alpha()
        {
            return Ok(new { branch = "A", tag = _settings.AlphaTag });
        }

        [HttpGet("beta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<object> Beta()
        {
            return Ok(new { branch = "B", payload = _formatter.FormatBeta(_settings) });
        }
    }
}
