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

        public DbSet<Device> Devices { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<EnergyUsage> EnergyUsages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>().HasKey(d => d.Id);
            modelBuilder.Entity<Alert>().HasKey(a => a.Id);
            modelBuilder.Entity<EnergyUsage>().HasKey(e => e.Id);
        }
    }
}
