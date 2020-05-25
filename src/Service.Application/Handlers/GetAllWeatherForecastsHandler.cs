using AutoMapper;
using MediatR;
using Service.Application.DTOs;
using Service.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Queries
{
    public class GetAllWeatherForecastsHandler : IRequestHandler<GetAllWeatherForecasts, ICollection<WeatherForecastDto>>
    {
        private readonly IReadOnlyRepository<WeatherForecast> _repository;
        private readonly IMapper _mapper;

        public GetAllWeatherForecastsHandler(IReadOnlyRepository<WeatherForecast> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<WeatherForecastDto>> Handle(GetAllWeatherForecasts request, CancellationToken cancellationToken)
        {
            var allWeatherForecasts = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<WeatherForecastDto>>(allWeatherForecasts);
        }
    }
}
