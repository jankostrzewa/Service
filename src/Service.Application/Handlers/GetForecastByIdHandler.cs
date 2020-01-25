using MediatR;
using Service.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Queries
{
    public class GetForecastByIdHandler : IRequestHandler<GetForecastById, WeatherForecast>
    {
        private readonly IRepository<WeatherForecast> _repository;

        public GetForecastByIdHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<WeatherForecast> Handle(GetForecastById request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
