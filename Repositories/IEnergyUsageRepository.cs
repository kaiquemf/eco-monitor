using EcoMonitor.Api.Models;

namespace EcoMonitor.Api.Repositories
{
    public interface IEnergyUsageRepository
    {
        Task<List<EnergyUsage>> GetPagedAsync(int page, int pageSize);
        Task<List<EnergyUsage>> GetByDeviceAndPeriodAsync(string deviceId, DateTime start, DateTime end);
        Task AddAsync(EnergyUsage usage);
    }
}
