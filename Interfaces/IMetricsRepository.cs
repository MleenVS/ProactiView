// C# ProactiView.Interfaces/IMetricsRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using ProactiView.Models;

namespace ProactiView.Interfaces
{
    public interface IMetricsRepository
    {
        Task<IEnumerable<Metric>> GetAllAsync();
        Task<Metric?> GetByIdAsync(int id);
        Task<IEnumerable<Metric>> GetByWebsiteIdAsync(int websiteId);
    }
}