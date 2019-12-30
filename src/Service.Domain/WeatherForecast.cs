using Service.Domain.SeedWork;
using System;

namespace Service.Domain
{
    public class WeatherForecast : Entity
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public static WeatherForecast Create()
        {
            var fc = new WeatherForecast();
            fc.Id = Guid.NewGuid();
            return fc;
        }
    }
}
