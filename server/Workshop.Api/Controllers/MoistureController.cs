using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Workshop.Api.Services;

namespace Workshop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoistureController : ControllerBase
    {
        private readonly IMoistureService _moistureService;
        private readonly ILogger<MoistureController> _logger;
        public MoistureController(IMoistureService moistureService, ILogger<MoistureController> logger)
        {
            _moistureService = moistureService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<int> GetMoisture()
        {
            return await _moistureService.GetRawMoisture();
        }
    }
}
