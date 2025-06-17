using EcoMonitor.Api.Data;
using EcoMonitor.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoMonitor.Api.Repositories
{
    public class EnergyUsageRepository : IEnergyUsageRepository
    {
        private readonly EnergyUsageDbContext _context;

        public EnergyUsageRepository(EnergyUsageDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EnergyUsage usage)
        {
            await _context.EnergyUsages.AddAsync(usage);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EnergyUsage>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.EnergyUsages
                .OrderByDescending(e => e.Timestamp)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<EnergyUsage>> GetByDeviceAsync(string deviceId)
        {
            return await _context.EnergyUsages
                .Where(e => e.DeviceId == deviceId)
                .OrderByDescending(e => e.Timestamp)
                .ToListAsync();
        }

        public async Task<List<EnergyUsage>> GetHighConsumptionAlertsAsync(double thresholdKwh)
        {
            return await _context.EnergyUsages
                .Where(e => e.KilowattHour > thresholdKwh)
                .OrderByDescending(e => e.Timestamp)
                .ToListAsync();
        }
    }
}
