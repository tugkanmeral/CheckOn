using Phoenix.Aspects.Logging;
using Phoenix.LayerBases.DataAccess;
using Phoenix.LayerBases.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.LayerBases.Business
{
    public abstract class ServiceBase<T, TId> : IService<T>
        where T : class, IEntity<TId>, new()
    {
        public IRepository<T, TId> _repository;
        public ServiceBase(IRepository<T, TId> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.AddAsync(entity);
        }

        [LogAspect]
        public Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return _repository.GetAsync(filter);
        }

        public Task<List<T>> GetList(Expression<Func<T, bool>> filter)
        {
            return _repository.GetListAsync(filter);
        }

        public void Update(T entity)
        {
            _repository.UpdateAsync(entity);
        }

        public void Delete(T entity)
        {
            _repository.DeleteAsync(entity);
        }
    }
}
