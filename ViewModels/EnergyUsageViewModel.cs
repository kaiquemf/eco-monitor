namespace EcoMonitor.Api.ViewModels
{
    public class EnergyUsageViewModel
    {
        public string DeviceId { get; set; } = string.Empty;
        public double KilowattHour { get; set; } = double.MinValue;
        public DateTime Timestamp { get; set; }
    }
}
