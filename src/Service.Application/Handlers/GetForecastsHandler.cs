using MediatR;
using Service.Application.ReturnModels;
using Service.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Queries
{
    public class GetForecastsHandler : IRequestHandler<GetForecasts, ICollection<WeatherForecastView>>
    {
        private readonly IRepository<WeatherForecast> _repository;

        public GetForecastsHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<ICollection<WeatherForecastView>> Handle(GetForecasts request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
