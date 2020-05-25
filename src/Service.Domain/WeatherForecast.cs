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
            Id = id;
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
            _humidities = humidities?.ToList() ?? new List<string>();
        }

        public void AddHumidity(string humidity)
        {
            _humidities.Add(humidity ?? throw new ArgumentNullException());
        }
    }
}
