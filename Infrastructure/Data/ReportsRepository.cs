using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProactiView.Interfaces;
using ProactiView.Models;

namespace ProactiView.Infrastructure.Data
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly ProactiViewDbContext _context;

        public ReportsRepository(ProactiViewDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<Report?> GetByIdAsync(int id)
        {
            return await _context.Reports.FindAsync(id);
        }
    }
}