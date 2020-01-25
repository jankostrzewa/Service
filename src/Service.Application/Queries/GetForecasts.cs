using MediatR;
using Service.Domain;
using System.Collections.Generic;

namespace Service.Application.Queries
{
    public class GetForecasts : IRequest<ICollection<WeatherForecast>>
    {
    }
}
