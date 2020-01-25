using MediatR;
using Service.Domain;

namespace Service.Application.Commands
{
    public class CreateNewForecast : IRequest<WeatherForecast>
    {
    }
}
