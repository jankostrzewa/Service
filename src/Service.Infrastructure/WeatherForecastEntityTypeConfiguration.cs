using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.Domain;
using System;

namespace Service.Infrastructure
{
    class WeatherForecastEntityTypeConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Humidities);

        }
    }
}
