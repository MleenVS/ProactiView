using Microsoft.AspNetCore.Mvc.RazorPages;
using ProactiView.Services;
using ProactiView.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProactiView.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly IMetricsService _metricsService;

        public List<MetricAggregateDto> Aggregates { get; set; } = new();

        public DashboardModel(IMetricsService metricsService)
        {
            _metricsService = metricsService;
        }

        public async Task OnGetAsync()
        {
            // Voorbeeld: laad aggregates van websites 1 t/m 3
            Aggregates = new List<MetricAggregateDto>();
            for (int websiteId = 1; websiteId <= 3; websiteId++)
            {
                var agg = await _metricsService.GetAggregateForWebsiteAsync(websiteId);
                Aggregates.Add(agg);
            }
        }
    }
}