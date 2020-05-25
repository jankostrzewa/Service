using MediatR;
using Service.Application.DTOs;
using System;

namespace Service.Application.Commands
{
    public class UpdateForecast : IRequest<WeatherForecastDto>
    {
        public Guid Id { get; }
        public UpdateWeatherForecastDto UpdateWeatherForecastDto { get; }

        public UpdateForecast(Guid id, UpdateWeatherForecastDto updateWeatherForecastDto)
        {
            Id = id;
            UpdateWeatherForecastDto = updateWeatherForecastDto;
        }
    }
}
