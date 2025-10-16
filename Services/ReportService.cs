using ProactiView.Interfaces;
using ProactiView.Models;
using ProactiView.Services;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ProactiView.Services
{
    public class ReportService : IReportService
    {
        private readonly IMetricsService _metricsService;
        private readonly IReportsRepository? _reportsRepository;

        // reportsRepository is optional so existing unit tests (which construct ReportService with only IMetricsService) still work.
        public ReportService(IMetricsService metricsService, IReportsRepository? reportsRepository = null)
        {
            _metricsService = metricsService;
            _reportsRepository = reportsRepository;
        }

        public async Task<Report> GenerateMockReportAsync(int websiteId, string period = "weekly")
        {
            var to = DateTime.UtcNow;
            var from = period == "weekly" ? to.AddDays(-7) : to.AddDays(-30);
            var agg = await _metricsService.GetAggregateForWebsiteAsync(websiteId, from, to);

            var sb = new StringBuilder();
            sb.AppendLine($"Report for website {websiteId} ({period})");
            sb.AppendLine($"Generated: {DateTime.UtcNow:u}");
            sb.AppendLine();

            if (agg.Count == 0)
            {
                sb.AppendLine("No metrics available in the selected period.");
            }
            else
            {
                sb.AppendLine($"Count: {agg.Count}");
                sb.AppendLine($"Average: {agg.Average:F2}");
                sb.AppendLine($"Min: {agg.Min:F2}");
                sb.AppendLine($"Max: {agg.Max:F2}");
                sb.AppendLine($"From: {agg.FirstTimestamp:u} To: {agg.LastTimestamp:u}");
            }

            var report = new Report
            {
                Title = $"Mock {period} report - website {websiteId}",
                Content = sb.ToString(),
                Created = DateTime.UtcNow,
                WebsiteId = websiteId
            };

            if (_reportsRepository != null)
            {
                await _reportsRepository.AddAsync(report);
            }

            return report;
        }
    }
}