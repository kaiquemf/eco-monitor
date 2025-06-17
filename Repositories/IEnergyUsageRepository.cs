using EcoMonitor.Api.Models;

namespace EcoMonitor.Api.Repositories
{
    public interface IEnergyUsageRepository
    {
        Task<List<EnergyUsage>> GetPagedAsync(int page, int pageSize);
        Task<List<EnergyUsage>> GetByDeviceAsync(string deviceId);
        Task AddAsync(EnergyUsage usage);
        Task<List<EnergyUsage>> GetHighConsumptionAlertsAsync(double thresholdKwh);
    }
}
