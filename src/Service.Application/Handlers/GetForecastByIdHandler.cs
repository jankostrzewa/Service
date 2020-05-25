using MediatR;
using Service.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Queries
{
    public class GetForecastByIdHandler : IRequestHandler<GetForecastById, WeatherForecast>
    {
        private readonly IReadonlyRepository<WeatherForecast> _repository;

        public GetForecastByIdHandler(IReadonlyRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<WeatherForecast> Handle(GetForecastById request, CancellationToken cancellationToken)
        {
            return null; //TODO
        }
    }
}
