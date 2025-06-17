using EcoMonitor.Api.Models;

namespace EcoMonitor.Api.Repositories
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetAllAsync();
        Task<Device?> GetByIdAsync(string deviceId);
        Task AddAsync(Device device);
        Task UpdateAsync(Device device);
        Task DeleteAsync(string deviceId);
    }
}
