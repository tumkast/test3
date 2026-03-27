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
        private readonly ILogger<CherryLabController> _logger;

        public CherryLabController(
            IOptions<CherryLabSettings> options,
            CherryLabFormatter formatter,
            ILogger<CherryLabController> logger)
        {
            _settings = options.Value;
            _formatter = formatter;
            _logger = logger;
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

        [HttpGet("gamma")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<object> Gamma()
        {
            _logger.LogDebug("Cherry-lab gamma invoked");
            return Ok(new
            {
                branch = "C",
                tag = _settings.GammaTag,
                formatted = _formatter.FormatGamma(_settings)
            });
        }
    }
}
