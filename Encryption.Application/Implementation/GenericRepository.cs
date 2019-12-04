using Encryptor.Persistence;
using MessageBroker.GenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace MessageBroker.GenericRepository.Implementation
{
    public class GenericRepository<EntityType> : IGenericRepository<EntityType> where EntityType : class
    {
        #region Fields
        private readonly EncryptorContext _context;
        private DbSet<EntityType> table = null;
        #endregion

        public GenericRepository()
        {
            _context = new EncryptorContext(null);
            table = _context.Set<EntityType>();
        }

        public EntityType GetById(Guid id)
        {
            return table.Find(id);
        }

        public IEnumerable<EntityType> GetList(Expression<Func<EntityType, bool>> _predicate)
        {
            return table.Where(_predicate);
        }

        public bool Save(EntityType entity)
        {
            try
            {
                table.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Saving the entitiy into the {0} table has occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }

        public bool SaveRange(IEnumerable<EntityType> entities)
        {
            try
            {
                table.AddRange(entities);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Saving entities into the {0} table has occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }

        public bool Update(EntityType entity)
        {
            try
            {
                table.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Updating the entity into the {0} table has occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }

        public bool UpdateRange(IEnumerable<EntityType> entities)
        {
            try
            {
                table.UpdateRange(entities);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Updating entities into the {0} table has occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }

        public bool Delete(EntityType entity)
        {
            try
            {
                table.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Removing the entity from the {0} table has occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }

        public bool DeleteRange(IEnumerable<EntityType> entities)
        {
            try
            {
                table.RemoveRange(entities);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error: Removing entities from the {0} table have occured " +
                    $"the following exception: {1}", nameof(EntityType), exception);
                return false;
            }

            return true;
        }
    }
}
