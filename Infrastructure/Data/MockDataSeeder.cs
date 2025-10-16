using ProactiView.Infrastructure.Data;
using ProactiView.Models;

public static class MockDataSeeder
{
    public static void Seed(ProactiViewDbContext context)
    {
        if (!context.Websites.Any())
        {
            var websites = new List<Website>
            {
                new Website { Name = "Site A", Url = "https://sitea.com" },
                new Website { Name = "Site B", Url = "https://siteb.com" }
            };

            context.Websites.AddRange(websites);
            context.SaveChanges();

            var metrics = new List<Metric>
            {
                new Metric { Type = "Performance", Value = 95.2, Timestamp = DateTime.UtcNow, WebsiteId = websites[0].Id },
                new Metric { Type = "Health", Value = 99.9, Timestamp = DateTime.UtcNow, WebsiteId = websites[1].Id }
            };

            context.Metrics.AddRange(metrics);
            context.SaveChanges();

            var reports = new List<Report>
            {
                new Report { Title = "Weekly Report", Content = "All good.", Created = DateTime.UtcNow, WebsiteId = websites[0].Id }
            };

            context.Reports.AddRange(reports);
            context.SaveChanges();
        }
    }
}