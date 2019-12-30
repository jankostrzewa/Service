using MediatR;
using Service.Application.ReturnModels;
using System;
using System.Collections.Generic;

namespace Service.Application.Queries
{
    public class GetForecastById : IRequest<WeatherForecastView>
    {
        Guid Id { get; }

        public GetForecastById(Guid id) => Id = id;
    }
}
