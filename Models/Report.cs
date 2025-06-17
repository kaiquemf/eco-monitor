using System;

namespace EcoMonitor.Api.Models
{
    public class Report
    {
        public required int Id { get; set; }
        public required string DeviceId { get; set; }
        public required int Year { get; set; }
        public required int Month { get; set; }
        public double TotalConsumption { get; set; }
        public double AveragePerDay { get; set; }

        public required Device Device { get; set; }
    }
}
