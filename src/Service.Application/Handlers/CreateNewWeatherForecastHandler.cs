using AutoMapper;
using MediatR;
using Service.Application.DTOs;
using Service.Application.Helpers;
using Service.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Commands
{
    public class CreateNewWeatherForecastHandler : IRequestHandler<CreateNewWeatherForecast, WeatherForecastDto>
    {
        private readonly IWriteOnlyRepository<WeatherForecast> _repository;
        private readonly IMapper _mapper;

        public CreateNewWeatherForecastHandler(IWriteOnlyRepository<WeatherForecast> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WeatherForecastDto> Handle(CreateNewWeatherForecast request, CancellationToken cancellationToken)
        {
            var newForecast = WeatherForecastBuilder.CreateNew(request.CreateWeatherForecastDto);
            newForecast = await _repository.AddAsync(newForecast);
            return _mapper.Map<WeatherForecastDto>(newForecast);
        }
    }
}
