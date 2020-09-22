using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Workshop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HumidityController : ControllerBase
    {
        private readonly ILogger<HumidityController> _logger;

        public HumidityController(ILogger<HumidityController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Humidity()
        {
            return 1;
        }
    }
}
