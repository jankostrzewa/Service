using Service.Application.DTOs;
using Service.Domain;
using System;

namespace Service.Application.Helpers
{
    public static class WeatherForecastBuilder
    {
        public static WeatherForecast CreateNew(CreateWeatherForecastDto createWeatherForecastDto)
        {
            var newForecast = new WeatherForecast(
                id: Guid.NewGuid(),
                date: createWeatherForecastDto.Date,
                temperatureC: createWeatherForecastDto.TemperatureC,
                summary: createWeatherForecastDto.Summary,
                humidities: createWeatherForecastDto.Humidities
            );
            return newForecast;
        }
    }
}
