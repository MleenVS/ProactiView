// C# Services/Dto/MetricAggregateDto.cs
using System;

namespace ProactiView.Services.Dto
{
    public class MetricAggregateDto
    {
        public int WebsiteId { get; set; }
        public int Count { get; set; }
        public double Average { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public DateTime? FirstTimestamp { get; set; }
        public DateTime? LastTimestamp { get; set; }
    }
}