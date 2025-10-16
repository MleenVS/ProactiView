using System.Collections.Generic;
using System.Threading.Tasks;
using ProactiView.Models;

namespace ProactiView.Interfaces
{
    public interface IReportsRepository
    {
        Task AddAsync(Report report);
        Task<IEnumerable<Report>> GetAllAsync();
        Task<Report?> GetByIdAsync(int id);
    }
}