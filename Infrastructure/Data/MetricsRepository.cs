using ProactiView.Infrastructure.Data;
using ProactiView.Interfaces;
using ProactiView.Models;

public class MetricsRepository : IMetricsRepository
{
    private readonly ProactiViewDbContext _context;

    public MetricsRepository(ProactiViewDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Metric>> GetAllAsync()
    {
        return await _context.Metrics.ToListAsync();
    }

    public async Task<Metric?> GetByIdAsync(int id)
    {
        return await _context.Metrics.FindAsync(id);
    }

    public async Task<IEnumerable<Metric>> GetByWebsiteIdAsync(int websiteId)
    {
        return await _context.Metrics.Where(m => m.WebsiteId == websiteId).ToListAsync();
    }
}