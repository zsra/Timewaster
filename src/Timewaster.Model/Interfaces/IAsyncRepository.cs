using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timewaster.Core.Entities;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(ServiceContext context, int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ListAllAsync(ServiceContext context, CancellationToken cancellationToken = default);
        Task<T> AddAsync(ServiceContext context, T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(ServiceContext context, T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(ServiceContext context, T entity, CancellationToken cancellationToken = default);
    }
}
