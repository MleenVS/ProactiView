
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ProactiView.Interfaces;
using ProactiView.Models;
using ProactiView.Services;
using Xunit;

namespace ProactiView.Tests.Services
{
    public class MetricsServiceTests
    {
        [Fact]
        public async Task GetAggregateForWebsiteAsync_ReturnsCorrectAggregates()
        {
            var now = DateTime.UtcNow;
            var metrics = new List<Metric>
            {
                new Metric { Id = 1, Value = 10, Timestamp = now.AddMinutes(-10), WebsiteId = 1 },
                new Metric { Id = 2, Value = 20, Timestamp = now.AddMinutes(-5), WebsiteId = 1 },
                new Metric { Id = 3, Value = 30, Timestamp = now, WebsiteId = 1 }
            };

            var mockRepo = new Mock<IMetricsRepository>();
            mockRepo.Setup(r => r.GetByWebsiteIdAsync(1)).ReturnsAsync(metrics);

            var service = new MetricsService(mockRepo.Object);

            var agg = await service.GetAggregateForWebsiteAsync(1);

            Assert.Equal(3, agg.Count);
            Assert.Equal(20, agg.Average);
            Assert.Equal(10, agg.Min);
            Assert.Equal(30, agg.Max);
            Assert.Equal(metrics.Min(m => m.Timestamp), agg.FirstTimestamp);
            Assert.Equal(metrics.Max(m => m.Timestamp), agg.LastTimestamp);
        }

        [Fact]
        public async Task GetMetricsForWebsiteAsync_FiltersByRange()
        {
            var now = DateTime.UtcNow;
            var metrics = new List<Metric>
            {
                new Metric { Id = 1, Value = 1, Timestamp = now.AddDays(-10), WebsiteId = 2 },
                new Metric { Id = 2, Value = 2, Timestamp = now.AddDays(-2), WebsiteId = 2 },
                new Metric { Id = 3, Value = 3, Timestamp = now.AddDays(-1), WebsiteId = 2 }
            };

            var mockRepo = new Mock<IMetricsRepository>();
            mockRepo.Setup(r => r.GetByWebsiteIdAsync(2)).ReturnsAsync(metrics);

            var service = new MetricsService(mockRepo.Object);

            var from = now.AddDays(-3);
            var to = now;
            var filtered = (await service.GetMetricsForWebsiteAsync(2, from, to)).ToList();

            Assert.Equal(2, filtered.Count);
            Assert.All(filtered, m => Assert.InRange(m.Timestamp, from, to));
        }
    }
}