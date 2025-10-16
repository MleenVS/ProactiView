// C# Services/IReportService.cs
using System.Threading.Tasks;
using ProactiView.Models;

namespace ProactiView.Services
{
    public interface IReportService
    {
        Task<Report> GenerateMockReportAsync(int websiteId, string period = "weekly");
    }
}