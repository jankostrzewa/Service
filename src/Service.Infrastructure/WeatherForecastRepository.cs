using Microsoft.EntityFrameworkCore;
using Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Infrastructure
{
    public class WeatherForecastRepository : IReadOnlyRepository<WeatherForecast>, IRepository<WeatherForecast>
    {
        private readonly WeatherForecastDbContext _context;

        public WeatherForecastRepository(WeatherForecastDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllAsNoTrackingAsync(CancellationToken ct = default)
        {
            return await _context.WeatherForecasts.AsNoTracking().ToListAsync(ct);
        }

        public async Task<WeatherForecast> GetByIdAsNoTrackingAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.WeatherForecasts.AsNoTracking().SingleAsync(x => x.Id == id, ct);
        }

        public async Task<WeatherForecast> GetLatestAsNoTrackingAsync(CancellationToken ct = default)
        {
            return await _context.WeatherForecasts.OrderByDescending(x => x.Date).AsNoTracking().FirstAsync(ct);
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.WeatherForecasts.ToListAsync(ct);
        }

        public async Task<WeatherForecast> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.WeatherForecasts.SingleAsync(x => x.Id == id, ct);
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

        public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entry = await _context.WeatherForecasts.FindAsync(id, ct);
            if(entry is null)
            {
                throw new InvalidOperationException();
            }
            _context.Remove(entry);
            var result = await _context.SaveChangesAsync(ct);
            return result == 1;
        }
    }
}
