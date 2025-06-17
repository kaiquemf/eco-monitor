using EcoMonitor.Api.Models;
using EcoMonitor.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoMonitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnergyUsageController : ControllerBase
    {
        private readonly EnergyUsageService _service;

        public EnergyUsageController(EnergyUsageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _service.GetPagedAsync(page, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnergyUsage input)
        {
            await _service.AddAsync(input);
            return CreatedAtAction(nameof(GetAll), null);
        }

        [HttpGet("device/{deviceId}")]
        public async Task<IActionResult> GetByDevice(string deviceId)
        {
            var result = await _service.GetByDeviceAsync(deviceId);
            return Ok(result);
        }

        [HttpGet("alerts")]
        public async Task<IActionResult> GetAlerts([FromQuery] double threshold = 100.0)
        {
            var result = await _service.GetHighConsumptionAlertsAsync(threshold);
            return Ok(result);
        }
    }
}
