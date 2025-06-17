using EcoMonitor.Api.Data;
using EcoMonitor.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoMonitor.Api.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        private readonly EnergyUsageDbContext _context;

        public AlertRepository(EnergyUsageDbContext context)
        {
            _context = context;
        }

        public async Task<List<Alert>> GetAllAsync()
        {
            return await _context.Alerts.ToListAsync();
        }

        public async Task<List<Alert>> GetByDeviceAndPeriodAsync(string deviceId, DateTime start, DateTime end)
        {
            return await _context.Alerts
                .Where(a => a.DeviceId == deviceId && a.CreatedAt >= start && a.CreatedAt <= end)
                .ToListAsync();
        }

        public async Task AddAsync(Alert alert)
        {
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();
        }
    }
}
