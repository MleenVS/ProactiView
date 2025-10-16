using Microsoft.EntityFrameworkCore;
using ProactiView.Models;


namespace ProactiView.Infrastructure.Data
{
    public class ProactiViewDbContext : DbContext
    {
        public ProactiViewDbContext(DbContextOptions<ProactiViewDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskTag>()
                .HasKey(tt => new { tt.TaskItemId, tt.TagId });
            modelBuilder.Entity<TaskTag>()
                .HasOne(tt => tt.TaskItem)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tt => tt.TaskItemId);
            modelBuilder.Entity<TaskTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tt => tt.TagId);
        }
    }
}
