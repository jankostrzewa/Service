using Service.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Infrastructure
{
    public class WeatherForecastRepository : IRepository<WeatherForecast>
    {
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeatherForecast>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast> UpdateAsync(WeatherForecast entity)
        {
            throw new NotImplementedException();
        }
    }
}
