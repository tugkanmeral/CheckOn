using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.LayerBases.Business
{
    public interface IService<T>
    {
        void Add(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        void Update(T entity);
        void Delete(T entity);
    }
}
