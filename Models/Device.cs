namespace EcoMonitor.Api.Models
{
    public class Device
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public bool IsActive { get; set; } = true;
        public List<EnergyUsage> EnergyUsages { get; set; } = [];
        public List<Alert> Alerts { get; set; } = [];
    }
}
