using MediatR;
using Service.Application.DTOs;

namespace Service.Application.Commands
{
    public class CreateNewWeatherForecast : IRequest<WeatherForecastDto>
    {
        public CreateWeatherForecastDto CreateWeatherForecastDto { get; }

        public CreateNewWeatherForecast(CreateWeatherForecastDto createWeatherForecastDto)
        {
            CreateWeatherForecastDto = createWeatherForecastDto;
        }
    }
}
