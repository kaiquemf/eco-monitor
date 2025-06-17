using EcoMonitor.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoMonitor.Api.Data
{
    public class EnergyUsageDbContext : DbContext
    {
        public EnergyUsageDbContext(DbContextOptions<EnergyUsageDbContext> options)
            : base(options)
        {
        }

        public DbSet<EnergyUsage> EnergyUsages { get; set; }
    }
}
