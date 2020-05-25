using AutoMapper;
using Service.Application.DTOs;
using Service.Domain;

namespace Service.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastDto>();
        }
    }
}
