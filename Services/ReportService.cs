using EcoMonitor.Api.Repositories;
using EcoMonitor.Api.ViewModels;

namespace EcoMonitor.Api.Services
{
    public class ReportService
    {
        private readonly IEnergyUsageRepository _usageRepository;
        private readonly IAlertRepository _alertRepository;
        private readonly IDeviceRepository _deviceRepository;

        public ReportService(IEnergyUsageRepository usageRepo, IAlertRepository alertRepo, IDeviceRepository deviceRepo)
        {
            _usageRepository = usageRepo;
            _alertRepository = alertRepo;
            _deviceRepository = deviceRepo;
        }

        public async Task<ReportViewModel> GenerateReportAsync(string deviceId, DateTime start, DateTime end)
        {
            var usages = await _usageRepository.GetByDeviceAndPeriodAsync(deviceId, start, end);
            var alerts = await _alertRepository.GetByDeviceAndPeriodAsync(deviceId, start, end);
            var device = await _deviceRepository.GetByIdAsync(deviceId);

            double total = usages.Sum(u => u.KilowattHour);
            double average = usages.Any() ? total / usages.Count : 0;

            return new ReportViewModel
            {
                DeviceName = device?.Name ?? "Unknown",
                PeriodStart = start,
                PeriodEnd = end,
                TotalConsumptionKwh = total,
                AverageConsumptionKwh = average,
                AlertCount = alerts.Count
            };
        }

        public async Task<IEnumerable<AlertViewModel>> GetHighConsumptionAlertsAsync(double threshold)
        {
            var alerts = await _alertRepository.GetAllAsync();

            return alerts
                .Where(a => a.ConsumptionValue > threshold)
                .Select(a => new AlertViewModel
                {
                    DeviceName = a.Device?.Name ?? "Unknown",
                    Message = a.Message,
                    CreatedAt = a.CreatedAt,
                    Severity = "High"
                });
        }


        public async Task<IEnumerable<ReportViewModel>> GeneratePagedReportAsync(int page, int pageSize)
        {
            var usages = await _usageRepository.GetPagedAsync(page, pageSize);
            var result = new List<ReportViewModel>();

            foreach (var usage in usages)
            {
                var alerts = await _alertRepository.GetByDeviceAndPeriodAsync(usage.DeviceId, usage.Timestamp.AddDays(-7), usage.Timestamp);
                var device = await _deviceRepository.GetByIdAsync(usage.DeviceId);

                result.Add(new ReportViewModel
                {
                    DeviceName = device?.Name ?? "Unknown",
                    PeriodStart = usage.Timestamp.AddDays(-7),
                    PeriodEnd = usage.Timestamp,
                    TotalConsumptionKwh = usage.KilowattHour,
                    AverageConsumptionKwh = usage.KilowattHour / 7,
                    AlertCount = alerts.Count
                });
            }

            return result;
        }
    }
}
