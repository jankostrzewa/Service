using Service.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Domain
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync(CancellationToken ct = default);

        Task<TEntity> GetByIdAsNoTrackingAsync(Guid id, CancellationToken ct = default);

        Task<TEntity> GetLatestAsNoTrackingAsync(CancellationToken ct = default);
    }
}
