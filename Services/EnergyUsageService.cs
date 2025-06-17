using EcoMonitor.Api.Repositories;
using EcoMonitor.Api.ViewModels;

namespace EcoMonitor.Api.Services
{
    public class EnergyUsageService
    {
        private readonly IEnergyUsageRepository _repository;

        public EnergyUsageService(IEnergyUsageRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EnergyUsageViewModel>> GetPagedViewModelAsync(int page, int pageSize)
        {
            var entities = await _repository.GetPagedAsync(page, pageSize);
            return entities.Select(e => new EnergyUsageViewModel
            {
                DeviceId = e.DeviceId,
                KilowattHour = e.KilowattHour,
                Timestamp = e.Timestamp
            }).ToList();
        }
    }
}
