using MediatR;
using Service.Application.ReturnModels;

namespace Service.Application.Commands
{
    public class CreateNewForecast : IRequest<WeatherForecastView>
    {
    }
}
