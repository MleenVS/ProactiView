using ProactiView.Infrastructure.Data;
using ProactiView.Interfaces;
using ProactiView.Models;

public class WebsiteStatusRepository : IWebsiteStatusRepository
{
    private readonly ProactiViewDbContext _context;

    public WebsiteStatusRepository(ProactiViewDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WebsiteStatus>> GetAllAsync()
    {
        return await _context.WebsiteStatuses.ToListAsync();
    }

    public async Task<WebsiteStatus?> GetByIdAsync(int id)
    {
        return await _context.WebsiteStatuses.FindAsync(id);
    }
}
