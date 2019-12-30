using MediatR;
using Service.Application.ReturnModels;
using System.Collections.Generic;

namespace Service.Application.Queries
{
    public class GetForecasts : IRequest<ICollection<WeatherForecastView>>
    {
    }
}
