using EcoMonitor.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EcoMonitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnergyUsageController : ControllerBase
    {
        private readonly IEnergyUsageRepository _energyRepo;

        public EnergyUsageController(IEnergyUsageRepository energyRepo)
        {
            _energyRepo = energyRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _energyRepo.GetPagedAsync(page, pageSize);
            return Ok(result);
        }

        [HttpGet("device/{deviceId}")]
        public async Task<IActionResult> GetByDeviceAndPeriod(string deviceId, DateTime start, DateTime end)
        {
            var result = await _energyRepo.GetByDeviceAndPeriodAsync(deviceId, start, end);
            return Ok(result);
        }
    }
}
