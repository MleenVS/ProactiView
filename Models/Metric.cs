// C# ProactiView.Models/Metric.cs
using System;

namespace ProactiView.Models
{
    public class Metric
    {
        public int Id { get; set; }
        public string Type { get; set; } = default!;
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
        public int WebsiteId { get; set; }
        public Website? Website { get; set; }
    }
}