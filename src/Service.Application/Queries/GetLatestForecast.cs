using MediatR;
using Service.Application.DTOs;

namespace Service.Application.Queries
{
    public class GetLatestForecast : IRequest<WeatherForecastDto>
    {
    }
}
