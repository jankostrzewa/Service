using MediatR;
using Service.Application.ReturnModels;
using Service.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Commands
{
    public class CreateNewForecastHandler : IRequestHandler<CreateNewForecast, WeatherForecastView>
    {
        private readonly IRepository<WeatherForecast> _repository;

        public CreateNewForecastHandler(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<WeatherForecastView> Handle(CreateNewForecast request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
