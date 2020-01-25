using MediatR;
using Service.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Queries
{
    public class GetForecastsHandler : IRequestHandler<GetForecasts, ICollection<WeatherForecast>>
    {
        private readonly IRepository<WeatherForecast> _repository;


        public GetForecastsHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<WeatherForecast>> Handle(GetForecasts request, CancellationToken cancellationToken)
        {
            return new List<WeatherForecast>() { WeatherForecast.Create() };
        }
    }
}
