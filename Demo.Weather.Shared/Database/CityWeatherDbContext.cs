using Demo.Weather.GraphQL;
using Demo.Weather.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Weather.Shared.Database
{
    public class CityWeatherDbContext : DbContext
    {
        public CityWeatherDbContext(DbContextOptions<CityWeatherDbContext> options) : base(options)
        {
            // Needed for seeing with ".HasData" :(
            Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasKey(c => c.Id);
            modelBuilder.Entity<City>().Property(c => c.Name).IsRequired();
            // modelBuilder.Entity<City>().HasMany(c => c.WeatherForecasts).WithOne(w => w.City);

            modelBuilder.Entity<City>().HasData(DataGenerator.GetCities());

            modelBuilder.Entity<WeatherForecast>().HasKey(w => w.Id);
            // modelBuilder.Entity<WeatherForecast>().HasOne(w => w.City).WithMany(c => c.WeatherForecasts);

            modelBuilder.Entity<WeatherForecast>().HasData(DataGenerator.GetWeatherForecasts(500));
        }
    }
}
