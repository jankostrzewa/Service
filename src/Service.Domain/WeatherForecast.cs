using Service.Domain.SeedWork;
using System;

namespace Service.Domain
{
    public class WeatherForecast : Entity
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public static WeatherForecast Create()
        {
            var random = new Random();
            var fc = new WeatherForecast();
            fc.Date = DateTime.Now.AddDays(random.Next(1, 15));
            fc.Id = Guid.NewGuid();
            fc.TemperatureC = random.Next(-30, 70);
            fc.Summary = Summaries[random.Next(0, 9)];
            return fc;
        }
    }
}
