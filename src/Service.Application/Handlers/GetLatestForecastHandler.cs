using MediatR;
using Service.Application.ReturnModels;
using Service.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Queries
{
    public class GetLatestForecastHandler : IRequestHandler<GetLatestForecast, WeatherForecastView>
    {
        private readonly IRepository<WeatherForecast> _repository;

        public GetLatestForecastHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<WeatherForecastView> Handle(GetLatestForecast request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
