using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workshop.Api.Services;

namespace Workshop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoistureController : ControllerBase
    {
        private readonly IMoistureService _moistureService;
        public MoistureController(IMoistureService moistureService)
        {
            _moistureService = moistureService;
        }

        [HttpGet]
        public async Task<int> GetMoisture()
        {
            return await _moistureService.GetRawMoisture();
        }
    }
}
