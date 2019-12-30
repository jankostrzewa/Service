using MediatR;
using Service.Application.ReturnModels;
using Service.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Queries
{
    public class GetForecastByIdHandler : IRequestHandler<GetForecastById, WeatherForecastView>
    {
        private readonly IRepository<WeatherForecast> _repository;

        public GetForecastByIdHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<WeatherForecastView> Handle(GetForecastById request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
