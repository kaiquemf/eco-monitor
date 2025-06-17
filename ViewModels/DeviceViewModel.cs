namespace EcoMonitor.Api.ViewModels
{
    public class DeviceViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
