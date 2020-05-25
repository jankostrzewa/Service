using MediatR;
using Service.Application.DTOs;
using Service.Application.Helpers;
using Service.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Commands
{
    public class UpdateForecastHandler : IRequestHandler<UpdateForecast, WeatherForecastDto>
    {
        private readonly IWriteOnlyRepository<WeatherForecast> _repository;

        public UpdateForecastHandler(IWriteOnlyRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public async Task<WeatherForecastDto> Handle(UpdateForecast request, CancellationToken cancellationToken)
        {
            //var existingEntity = await _repository.GetByIdAsync(request.Id);
            return null; // TODO
        }
    }
}
