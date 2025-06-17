namespace EcoMonitor.Api.ViewModels
{
    public class AlertViewModel
    {
        public string DeviceId { get; set; } = string.Empty;
        public string DeviceName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Severity { get; set; } = string.Empty;
    }
}
