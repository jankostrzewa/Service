using Service.Domain.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Domain
{
    public interface IWriteOnlyRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
