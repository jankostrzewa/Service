using System;
using System.Collections.Generic;

namespace Service.Application.DTOs
{
    public class CreateWeatherForecastDto
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
        public IEnumerable<string> Humidities { get; internal set; }
    }
}
