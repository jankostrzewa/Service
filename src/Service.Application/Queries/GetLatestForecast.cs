using MediatR;
using Service.Domain;

namespace Service.Application.Queries
{
    public class GetLatestForecast : IRequest<WeatherForecast>
    {
    }
}
