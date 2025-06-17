using EcoMonitor.Api.Repositories;
using EcoMonitor.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoMonitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        private readonly IAlertRepository _alertRepo;

        public AlertController(IAlertRepository alertRepo)
        {
            _alertRepo = alertRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _alertRepo.GetAllAsync());

        [HttpGet("device/{deviceId}")]
        public async Task<IActionResult> GetByDeviceAndPeriod(string deviceId, [FromQuery] DateTime? start, [FromQuery] DateTime? end)
        {
            var startDate = start ?? DateTime.MinValue;
            var endDate = end ?? DateTime.MaxValue;

            var alerts = await _alertRepo.GetByDeviceAndPeriodAsync(deviceId, startDate, endDate);
            return Ok(alerts);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Alert alert)
        {
            await _alertRepo.AddAsync(alert);
            return Ok(alert);
        }
    }
}
