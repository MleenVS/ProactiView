using ProactiView.Models;

namespace ProactiView.Interfaces;

public interface IWebsiteStatusRepository
{
    Task<IEnumerable<WebsiteStatus>> GetAllAsync();
    Task<WebsiteStatus?> GetByIdAsync(int id);
    // Add other CRUD methods as needed
}