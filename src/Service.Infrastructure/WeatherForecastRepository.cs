using Microsoft.EntityFrameworkCore;
using Service.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Infrastructure
{
    public class WeatherForecastRepository : IReadOnlyRepository<WeatherForecast>, IWriteOnlyRepository<WeatherForecast>
    {
        private readonly WeatherForecastDbContext _context;

        public WeatherForecastRepository(WeatherForecastDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.WeatherForecasts.AsNoTracking().ToListAsync(ct);
        }

        public async Task<WeatherForecast> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.WeatherForecasts.AsNoTracking().SingleAsync(x => x.Id == id, ct);
        }
        public async Task<WeatherForecast> AddAsync(WeatherForecast entity, CancellationToken ct = default)
        {
            var newEntry = _context.Add(entity ?? throw new ArgumentNullException());
            await _context.SaveChangesAsync(ct);
            var newEntity = newEntry.Entity;
            _context.Entry(newEntry).State = EntityState.Detached;
            return newEntity;
        }

        public async Task<WeatherForecast> UpdateAsync(WeatherForecast entity, CancellationToken ct = default)
        {
            var updatedEntry = _context.WeatherForecasts.Update(entity);
            await _context.SaveChangesAsync(ct);
            return updatedEntry.Entity;
        }

        public Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
