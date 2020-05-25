using Service.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Domain
{
    public interface IReadonlyRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct = default);

        Task<TEntity> GetByIdAsync(Guid id, CancellationToken ct = default);
    }
}
