using MediatR;
using Service.Application.DTOs;
using System.Collections.Generic;

namespace Service.Application.Queries
{
    public class GetAllWeatherForecasts : IRequest<ICollection<WeatherForecastDto>>
    {
    }
}
