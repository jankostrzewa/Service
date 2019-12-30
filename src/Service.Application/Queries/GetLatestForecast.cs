using MediatR;
using Service.Application.ReturnModels;

namespace Service.Application.Queries
{
    public class GetLatestForecast : IRequest<WeatherForecastView>
    {
    }
}
