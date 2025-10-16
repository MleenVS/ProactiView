using ProactiView.Models;

public interface IMetricsRepository
{
    Task<IEnumerable<Metric>> GetAllAsync();
    Task<Metric?> GetByIdAsync(int id);
    Task<IEnumerable<Metric>> GetByWebsiteIdAsync(int websiteId);
}