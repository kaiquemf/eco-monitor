namespace EcoMonitor.Api.Models
{
    public class EnergyUsage
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public double KilowattHour { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
