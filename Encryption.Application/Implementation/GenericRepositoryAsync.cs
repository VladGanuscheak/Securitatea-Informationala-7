using Encryption.Domain;
using Encryptor.Persistence;
using MessageBroker.GenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MessageBroker.GenericRepository.Implementation
{
    public class GenericRepositoryAsync<EntityType> : IGenericRepositoryAsync<EntityType> where EntityType : class
    {
        #region Fields
        private readonly IEncryptorContext _context;
        private DbSet<EntityType> table = null;
        #endregion

        public GenericRepositoryAsync(IEncryptorContext context)
        {
            _context = context;
            table = _context.Set<EntityType>();
        }

        public async Task<EntityType> GetByIdAsync(Guid id)
        {
            return await table.FindAsync(id);
        }

        public async Task<IEnumerable<EntityType>> GetListAsync(Expression<Func<EntityType, bool>> _predicate)
        {
            return await table.Where(_predicate).ToListAsync();
        }

        public async Task<bool> SaveAsync(EntityType entity, CancellationToken cancellationToken)
        {
            try
            {
                await table.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Saving async the entitiy into the {0} table has occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }

        public async Task<bool> SaveRangeAsync(IEnumerable<EntityType> entities, CancellationToken cancellationToken)
        {
            try
            {
                await table.AddRangeAsync(entities, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Saving async entities into the {0} table has occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateAsync(EntityType entity, CancellationToken cancellationToken)
        {
            try
            {
                table.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Updating async the entity into the {0} table has occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateRangeAsync(IEnumerable<EntityType> entities, CancellationToken cancellationToken)
        {
            try
            {
                table.UpdateRange(entities);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Updating async entities into the {0} table has occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteAsync(EntityType entity, CancellationToken cancellationToken)
        {
            try
            {
                table.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Removing async the entity from the {0} table has occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteRangeAsync(IEnumerable<EntityType> entities, CancellationToken cancellationToken)
        {
            try
            {
                table.RemoveRange(entities);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Removing async entities from the {0} table have occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }
    }
}
