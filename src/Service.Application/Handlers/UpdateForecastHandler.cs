using MediatR;
using Service.Application.ReturnModels;
using Service.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Commands
{
    public class UpdateForecastHandler : IRequestHandler<UpdateForecast, WeatherForecastView>
    {
        private readonly IRepository<WeatherForecast> _repository;

        public UpdateForecastHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<WeatherForecastView> Handle(UpdateForecast request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
