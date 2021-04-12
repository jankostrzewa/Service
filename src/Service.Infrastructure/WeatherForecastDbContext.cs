using Microsoft.EntityFrameworkCore;
using Service.Domain;
using System;

namespace Service.Infrastructure
{
    public class WeatherForecastDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeatherForecastEntityTypeConfiguration());

            modelBuilder.Entity<WeatherForecast>().HasData(
                new WeatherForecast(Guid.NewGuid(), DateTime.UtcNow, 0, "summary", new string[] { })
            );
        }
    }
}
