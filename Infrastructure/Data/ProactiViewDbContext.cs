
using Microsoft.EntityFrameworkCore;
using ProactiView.Models;

namespace ProactiView.Infrastructure.Data
{
    public class ProactiViewDbContext : DbContext
    {
        public ProactiViewDbContext(DbContextOptions<ProactiViewDbContext> options) : base(options) { }

        // Keep only the domain sets you need now
        public DbSet<Website> Websites { get; set; }
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<WebsiteStatus> WebsiteStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Website -> Metrics (1..*)
            modelBuilder.Entity<Website>()
                .HasMany(w => w.Metrics)
                .WithOne(m => m.Website)
                .HasForeignKey(m => m.WebsiteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Website -> Reports (1..*)
            modelBuilder.Entity<Website>()
                .HasMany(w => w.Reports)
                .WithOne(r => r.Website)
                .HasForeignKey(r => r.WebsiteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Website -> WebsiteStatuses (1..*)
            modelBuilder.Entity<Website>()
                .HasMany(w => w.WebsiteStatuses)
                .WithOne(s => s.Website)
                .HasForeignKey(s => s.WebsiteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}