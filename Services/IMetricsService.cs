// C# Services/IMetricsService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProactiView.Models;
using ProactiView.Services.Dto;

namespace ProactiView.Services
{
    public interface IMetricsService
    {
        Task<IEnumerable<Metric>> GetMetricsForWebsiteAsync(int websiteId, DateTime? from = null, DateTime? to = null);
        Task<MetricAggregateDto> GetAggregateForWebsiteAsync(int websiteId, DateTime? from = null, DateTime? to = null);
    }
}