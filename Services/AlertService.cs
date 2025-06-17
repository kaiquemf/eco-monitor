using EcoMonitor.Api.Repositories;
using EcoMonitor.Api.ViewModels;

namespace EcoMonitor.Api.Services
{
    public class AlertService(IAlertRepository repository)
    {
        private readonly IAlertRepository _repository = repository;

        public async Task<List<AlertViewModel>> GetAlertsAsync()
        {
            var alerts = await _repository.GetAllAsync();
            return [.. alerts.Select(alert => new AlertViewModel
            {
                DeviceId = alert.DeviceId,
                Message = alert.Message,
                CreatedAt = alert.CreatedAt,
                Severity = alert.Severity
            })];
        }
    }
}
