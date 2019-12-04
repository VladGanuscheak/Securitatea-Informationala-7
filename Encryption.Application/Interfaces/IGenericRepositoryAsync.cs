using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MessageBroker.GenericRepository.Interfaces
{
    public interface IGenericRepositoryAsync<EntityType> where EntityType : class
    {
        Task<EntityType> GetByIdAsync(Guid id);

        Task<IEnumerable<EntityType>> GetListAsync(Expression<Func<EntityType, bool>> _predicate);

        Task<bool> SaveAsync(EntityType entity, CancellationToken cancellationToken);

        Task<bool> SaveRangeAsync(IEnumerable<EntityType> entities, CancellationToken cancellationToken);

        Task<bool> UpdateAsync(EntityType entity, CancellationToken cancellationToken);

        Task<bool> UpdateRangeAsync(IEnumerable<EntityType> entities, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(EntityType entity, CancellationToken cancellationToken);

        Task<bool> DeleteRangeAsync(IEnumerable<EntityType> entities, CancellationToken cancellationToken);
    }
}
