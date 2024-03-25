using Analysis.Business.Abstract;
using Analysis.Data.Repositories.Concrete;
using Analysis.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Analysis.Business.Concrete
{
    public class ManagerBase<T, TId, TContext> : IManager<T, TId>
        where T : BaseEntity<TId>
        where TContext : DbContext, new()
    {
        public readonly RepositoryBase<T, TId, TContext> _repository;

        public ManagerBase()
        {
            _repository = new RepositoryBase<T, TId, TContext>();
        }

        public virtual async Task<int> Insert(T entity)
        {
            return await _repository.Insert(entity);
        }

        public virtual async Task<int> Update(T entity)
        {
            return await _repository.Update(entity);

        }
        public virtual async Task<int> Delete(T entity)
        {
            return await _repository.Delete(entity);
        }

        public virtual async Task<int> Delete(TId id)
        {
            return await (_repository.Delete(id));
        }

        public virtual async Task<T?> Get(Expression<Func<T, bool>> expression)
        {
            return _repository.Get(expression).Result;
        }

        public virtual async Task<ICollection<T>?> GetAll(Expression<Func<T, bool>>? expression = null)
        {
            return await _repository.GetAll(expression);
        }

        public virtual async Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[] include)
        {
            return await _repository.GetAllInclude(expression, include);
        }

        public virtual async Task<T> GetById(TId id)
        {
            return _repository.GetById(id).Result;
        }


    }
}
