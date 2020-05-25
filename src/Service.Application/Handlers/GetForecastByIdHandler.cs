using MediatR;
using Service.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Queries
{
    public class GetForecastByIdHandler : IRequestHandler<GetForecastById, WeatherForecast>
    {
        private readonly IReadOnlyRepository<WeatherForecast> _repository;

        public GetForecastByIdHandler(IReadOnlyRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<WeatherForecast> Handle(GetForecastById request, CancellationToken cancellationToken)
        {
            return null; //TODO
        }
    }
}
