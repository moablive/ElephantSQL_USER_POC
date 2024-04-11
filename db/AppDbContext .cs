using Microsoft.EntityFrameworkCore;
using ElephantSQL.Models;

namespace ElephantSQL.db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<userMODEL> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<userMODEL>(entity =>
            {
                entity.ToTable("user");
                entity.Property(e => e.id).HasColumnName("Id");
                entity.Property(e => e.name).HasColumnName("Name");
                entity.Property(e => e.email).HasColumnName("Email");
            });
        }
    }
}