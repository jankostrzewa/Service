using MediatR;
using Service.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Commands
{
    public class UpdateForecastHandler : IRequestHandler<UpdateForecast, WeatherForecast>
    {
        private readonly IRepository<WeatherForecast> _repository;

        public UpdateForecastHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<WeatherForecast> Handle(UpdateForecast request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
