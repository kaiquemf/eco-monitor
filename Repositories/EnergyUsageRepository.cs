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

        public async Task<List<EnergyUsage>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.EnergyUsages
                .OrderByDescending(e => e.Timestamp)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<EnergyUsage>> GetByDeviceAndPeriodAsync(string deviceId, DateTime start, DateTime end)
        {
            return await _context.EnergyUsages
                .Where(e => e.DeviceId == deviceId && e.Timestamp >= start && e.Timestamp <= end)
                .ToListAsync();
        }

        public async Task AddAsync(EnergyUsage usage)
        {
            _context.EnergyUsages.Add(usage);
            await _context.SaveChangesAsync();
        }
    }
}
