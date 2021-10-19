using AutoMapper;
using MediatR;
using Service.Application.DTOs;
using Service.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Commands
{
    public class UpdateForecastHandler : IRequestHandler<UpdateForecast, WeatherForecastDto>
    {
        private readonly IRepository<WeatherForecast> _repository;
        private readonly IMapper _mapper;

        public UpdateForecastHandler(IRepository<WeatherForecast> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WeatherForecastDto> Handle(UpdateForecast request, CancellationToken cancellationToken)
        {
            var existingEntity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            _mapper.Map(request.UpdateWeatherForecastDto, existingEntity);
            var result = await _repository.UpdateAsync(existingEntity, cancellationToken);
            return _mapper.Map<WeatherForecastDto>(result);
        }
    }
}
