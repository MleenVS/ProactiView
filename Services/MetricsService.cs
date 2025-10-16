// C# Services/MetricsService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProactiView.Interfaces;
using ProactiView.Models;
using ProactiView.Services.Dto;

namespace ProactiView.Services
{
    public class MetricsService : IMetricsService
    {
        private readonly IMetricsRepository _metricsRepo;

        public MetricsService(IMetricsRepository metricsRepo)
        {
            _metricsRepo = metricsRepo;
        }

        public async Task<IEnumerable<Metric>> GetMetricsForWebsiteAsync(int websiteId, DateTime? from = null, DateTime? to = null)
        {
            var metrics = (await _metricsRepo.GetByWebsiteIdAsync(websiteId)) ?? Enumerable.Empty<Metric>();
            var q = metrics.AsQueryable();
            if (from.HasValue) q = q.Where(m => m.Timestamp >= from.Value);
            if (to.HasValue) q = q.Where(m => m.Timestamp <= to.Value);
            return q.OrderBy(m => m.Timestamp).ToList();
        }

        public async Task<MetricAggregateDto> GetAggregateForWebsiteAsync(int websiteId, DateTime? from = null, DateTime? to = null)
        {
            var list = (await GetMetricsForWebsiteAsync(websiteId, from, to)).ToList();
            if (!list.Any())
            {
                return new MetricAggregateDto { WebsiteId = websiteId, Count = 0 };
            }

            return new MetricAggregateDto
            {
                WebsiteId = websiteId,
                Count = list.Count,
                Average = list.Average(m => m.Value),
                Min = list.Min(m => m.Value),
                Max = list.Max(m => m.Value),
                FirstTimestamp = list.Min(m => m.Timestamp),
                LastTimestamp = list.Max(m => m.Timestamp)
            };
        }
    }
}