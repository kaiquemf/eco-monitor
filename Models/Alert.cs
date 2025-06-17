namespace EcoMonitor.Api.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public required string DeviceId { get; set; }
        public required string Message { get; set; }
        public double ConsumptionValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Type { get; set; } = "HighConsumption";
        public double Threshold { get; set; }
        public string Severity { get; set; } = "High";

        public Device? Device { get; set; }
    }
}