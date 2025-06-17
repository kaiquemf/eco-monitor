namespace EcoMonitor.Api.ViewModels
{
    public class EnergyUsageViewModel
    {
        public string DeviceId { get; set; }
        public double KilowattHour { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
