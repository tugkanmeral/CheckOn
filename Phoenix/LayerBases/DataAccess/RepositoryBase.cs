using Microsoft.EntityFrameworkCore;
using Phoenix.LayerBases.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.LayerBases.DataAccess
{
    public abstract class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>, new()
    {
        private DbContext _context;
        public RepositoryBase(DbContextBase context)
        {
            _context = context;
        }

        public virtual void AddAsync(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChangesAsync();
        }

        public virtual void DeleteAsync(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChangesAsync();
        }

        public virtual Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Where(filter).FirstOrDefaultAsync();
        }

        public virtual Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToListAsync()
                : _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public virtual void UpdateAsync(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
