namespace EcoMonitor.Api.Models
{
    public class EnergyUsage
    {
        public required Guid Id { get; set; }
        public required string DeviceId { get; set; }
        public required double KilowattHour { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
