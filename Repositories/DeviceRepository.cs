using EcoMonitor.Api.Data;
using EcoMonitor.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoMonitor.Api.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly EnergyUsageDbContext _context;

        public DeviceRepository(EnergyUsageDbContext context)
        {
            _context = context;
        }

        public async Task<List<Device>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task<Device?> GetByIdAsync(string deviceId)
        {
            return await _context.Devices.FindAsync(deviceId);
        }

        public async Task AddAsync(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Device device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string deviceId)
        {
            var device = await GetByIdAsync(deviceId);
            if (device != null)
            {
                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();
            }
        }
    }
}
