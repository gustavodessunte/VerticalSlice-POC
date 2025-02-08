using Microsoft.EntityFrameworkCore;
using VerticalSlice.Domain;

namespace VerticalSlice.Infrastructure.Context
{
    public class ProductDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product?> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
