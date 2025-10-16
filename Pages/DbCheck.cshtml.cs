using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProactiView.Interfaces;
using ProactiView.Models;
using ProactiView.Services;
using System.Linq;
using System.Threading.Tasks;

namespace ProactiView.Pages
{
    public class DbCheckModel : PageModel
    {
        private readonly IMetricsRepository _metricsRepo;
        private readonly IWebsiteStatusRepository _statusRepo;
        private readonly IReportService _reportService;

        public int MetricCount { get; private set; }
        public int WebsiteStatusCount { get; private set; }
        public IEnumerable<Metric> SampleMetrics { get; private set; } = new List<Metric>();
        public string? ErrorMessage { get; private set; }

        [BindProperty]
        public int WebsiteIdInput { get; set; } = 1;

        [BindProperty]
        public string Period { get; set; } = "weekly";

        public Report? GeneratedReport { get; private set; }

        public DbCheckModel(IMetricsRepository metricsRepo, IWebsiteStatusRepository statusRepo, IReportService reportService)
        {
            _metricsRepo = metricsRepo;
            _statusRepo = statusRepo;
            _reportService = reportService;
        }

        public async Task OnGetAsync()
        {
            try
            {
                var metrics = await _metricsRepo.GetAllAsync();
                MetricCount = metrics?.Count() ?? 0;
                SampleMetrics = metrics?.Take(5) ?? new List<Metric>();

                var statuses = await _statusRepo.GetAllAsync();
                WebsiteStatusCount = statuses?.Count() ?? 0;
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        public async Task<IActionResult> OnPostGenerateAsync()
        {
            try
            {
                GeneratedReport = await _reportService.GenerateMockReportAsync(WebsiteIdInput, Period);
                return Page();
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }
}