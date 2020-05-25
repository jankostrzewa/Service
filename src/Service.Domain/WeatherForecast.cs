using Service.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Domain
{
    public class WeatherForecast : Entity
    {
        public DateTime Date { get; }

        public int TemperatureC { get; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; }

        public IReadOnlyList<string> Humidities { get => _humidities; }

        private List<string> _humidities;

        public WeatherForecast(Guid id, DateTime date, int temperatureC, string summary, IEnumerable<string> humidities)
        {
            Id = id != default ? id : throw new ArgumentException();
            Date = date != default ? date : throw new ArgumentException();
            TemperatureC = temperatureC;
            Summary = !string.IsNullOrWhiteSpace(summary) ? summary : throw new ArgumentException();
            _humidities = humidities?.ToList() ?? new List<string>();
        }

        public void AddHumidity(string humidity)
        {
            if (string.IsNullOrWhiteSpace(humidity))
            {
                throw new ArgumentException();
            }
            _humidities.Add(humidity);
        }
    }
}
