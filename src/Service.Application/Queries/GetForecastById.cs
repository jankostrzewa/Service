using MediatR;
using Service.Domain;
using System;

namespace Service.Application.Queries
{
    public class GetForecastById : IRequest<WeatherForecast>
    {
        Guid Id { get; }

        public GetForecastById(Guid id) => Id = id;
    }
}
