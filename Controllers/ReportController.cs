using EcoMonitor.Api.Services;
using EcoMonitor.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcoMonitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{deviceId}/period")]
        public async Task<ActionResult<ReportViewModel>> GenerateReport(string deviceId, DateTime start, DateTime end)
        {
            var report = await _reportService.GenerateReportAsync(deviceId, start, end);
            return Ok(report);
        }

        [HttpGet("alerts/high")]
        public async Task<IActionResult> GetHighConsumptionAlerts([FromQuery] double threshold)
        {
            var alerts = await _reportService.GetHighConsumptionAlertsAsync(threshold);
            return Ok(alerts);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedReports(int page = 1, int pageSize = 10)
        {
            var pagedReports = await _reportService.GeneratePagedReportAsync(page, pageSize);
            return Ok(pagedReports);
        }
    }
}
