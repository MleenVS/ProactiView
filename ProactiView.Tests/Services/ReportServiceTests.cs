
using System;
using System.Threading.Tasks;
using Moq;
using ProactiView.Services;
using ProactiView.Services.Dto;
using Xunit;

namespace ProactiView.Tests.Services
{
    public class ReportServiceTests
    {
        [Fact]
        public async Task GenerateMockReportAsync_ReturnsReportWithContent()
        {
            var websiteId = 5;
            var dto = new MetricAggregateDto
            {
                WebsiteId = websiteId,
                Count = 3,
                Average = 12.34,
                Min = 5,
                Max = 20,
                FirstTimestamp = DateTime.UtcNow.AddDays(-2),
                LastTimestamp = DateTime.UtcNow
            };

            var mockMetricsService = new Mock<IMetricsService>();
            mockMetricsService
                .Setup(s => s.GetAggregateForWebsiteAsync(websiteId, It.IsAny<DateTime?>(), It.IsAny<DateTime?>()))
                .ReturnsAsync(dto);

            var service = new ReportService(mockMetricsService.Object);

            var report = await service.GenerateMockReportAsync(websiteId, "weekly");

            Assert.NotNull(report);
            Assert.Contains($"website {websiteId}", report.Title, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("Count:", report.Content);
            Assert.Contains(dto.Count.ToString(), report.Content);
        }
    }
}