using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MessageBroker.GenericRepository.Interfaces
{
    public interface IGenericRepository<EntityType> where EntityType : class
    {
        EntityType GetById(Guid id);

        IEnumerable<EntityType> GetList(Expression<Func<EntityType, bool>> _predicate);

        bool Save(EntityType entity);

        bool SaveRange(IEnumerable<EntityType> entities);

        bool Update(EntityType entity);

        bool UpdateRange(IEnumerable<EntityType> entities);

        bool Delete(EntityType entity);

        bool DeleteRange(IEnumerable<EntityType> entities);
    }
}
