using Microsoft.EntityFrameworkCore;
using Service.Domain;

namespace Service.Infrastructure
{
    public class WeatherForecastDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeatherForecastEntityTypeConfiguration());
        }
    }
}
