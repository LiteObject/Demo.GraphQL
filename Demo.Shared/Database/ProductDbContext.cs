using Demo.Weather.GraphQL;
using Demo.Weather.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Weather.Shared.Database
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(c => c.Id);
            // modelBuilder.Entity<Product>().HasData(DataGenerator.GetProducts());
        }
    }
}
