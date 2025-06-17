using EcoMonitor.Api.Models;

namespace EcoMonitor.Api.Repositories
{
    public interface IAlertRepository
    {
        Task<List<Alert>> GetAllAsync();
        Task<List<Alert>> GetByDeviceAndPeriodAsync(string deviceId, DateTime start, DateTime end);
        Task AddAsync(Alert alert);
    }
}
