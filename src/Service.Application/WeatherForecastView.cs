using System;

namespace Service.Application.ReturnModels
{
    public class WeatherForecastView
    {
        public DateTime Date { get; internal set; }
        public int TemperatureC { get; internal set; }
        public string Summary { get; internal set; }
    }
}
