using System;
using System.Collections.Generic;

namespace Service.Application.DTOs
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
        public IEnumerable<string> Humidities { get; set; }

    }
}
