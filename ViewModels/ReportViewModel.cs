namespace EcoMonitor.Api.ViewModels
{
    public class ReportViewModel
    {
        public string DeviceName { get; set; } = string.Empty;
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public double TotalConsumptionKwh { get; set; }
        public double AverageConsumptionKwh { get; set; }
        public int AlertCount { get; set; }
    }
}
