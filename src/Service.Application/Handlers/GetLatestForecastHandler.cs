using AutoMapper;
using MediatR;
using Service.Application.DTOs;
using Service.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Queries
{
    public class GetLatestForecastHandler : IRequestHandler<GetLatestForecast, WeatherForecastDto>
    {
        private readonly IReadOnlyRepository<WeatherForecast> _repository;
        private readonly IMapper _mapper;

        public GetLatestForecastHandler(IReadOnlyRepository<WeatherForecast> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WeatherForecastDto> Handle(GetLatestForecast request, CancellationToken cancellationToken)
        {
            var result = await  _repository.GetLatestAsNoTrackingAsync(cancellationToken);
            return _mapper.Map<WeatherForecastDto>(result);
        }
    }
}
