using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Workshop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoistureController : ControllerBase
    {
        private readonly ILogger<MoistureController> _logger;
        public MoistureController(ILogger<MoistureController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int GetMoisture()
        {
            return 1;
        }
    }
}
