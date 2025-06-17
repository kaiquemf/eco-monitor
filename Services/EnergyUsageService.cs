using EcoMonitor.Api.Models;
using EcoMonitor.Api.Repositories;

namespace EcoMonitor.Api.Services
{
    public class EnergyUsageService
    {
        private readonly IEnergyUsageRepository _repository;

        public EnergyUsageService(IEnergyUsageRepository repository)
        {
            _repository = repository;
        }

        public Task<List<EnergyUsage>> GetPagedAsync(int page, int pageSize)
            => _repository.GetPagedAsync(page, pageSize);

        public Task<List<EnergyUsage>> GetByDeviceAsync(string deviceId)
            => _repository.GetByDeviceAsync(deviceId);

        public Task AddAsync(EnergyUsage usage)
            => _repository.AddAsync(usage);

        public Task<List<EnergyUsage>> GetHighConsumptionAlertsAsync(double thresholdKwh)
            => _repository.GetHighConsumptionAlertsAsync(thresholdKwh);
    }
}
