﻿using MediatR;
using Service.Application.DTOs;
using Service.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Queries
{
    public class GetLatestForecastHandler : IRequestHandler<GetLatestForecast, WeatherForecastDto>
    {
        private readonly IReadOnlyRepository<WeatherForecast> _repository;

        public GetLatestForecastHandler(IReadOnlyRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public Task<WeatherForecastDto> Handle(GetLatestForecast request, CancellationToken cancellationToken)
        {
            return null; //TODO
        }
    }
}
