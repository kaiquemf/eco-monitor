using EcoMonitor.Api.Repositories;
using EcoMonitor.Api.ViewModels;

namespace EcoMonitor.Api.Services
{
    public class DeviceService
    {
        private readonly IDeviceRepository _repository;

        public DeviceService(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DeviceViewModel>> GetAllAsync()
        {
            var devices = await _repository.GetAllAsync();
            return devices.Select(device => new DeviceViewModel
            {
                Name = device.Name,
                Location = device.Location,
                IsActive = device.IsActive
            }).ToList();
        }
    }
}
