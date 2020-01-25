using MediatR;
using Service.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Queries
{
    public class GetLatestForecastHandler : IRequestHandler<GetLatestForecast, WeatherForecast>
    {
        private readonly IRepository<WeatherForecast> _repository;

        public GetLatestForecastHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<WeatherForecast> Handle(GetLatestForecast request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
