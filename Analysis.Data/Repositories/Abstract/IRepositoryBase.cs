using Analysis.Entities.Abstract;
using System.Linq.Expressions;

namespace Analysis.Data.Repositories.Abstract
{
    public interface IRepositoryBase<T, TId> where T : BaseEntity<TId>
    {
        public Task<int> Insert(T entity);
        public Task<int> Update(T entity);
        public Task<int> Delete(T entity);
        public Task<int> Delete(TId id);

        public Task<T> GetById(TId id);
        public Task<T?> Get(Expression<Func<T, bool>> expression);
        public Task<ICollection<T>?> GetAll(Expression<Func<T, bool>>? expression = null);

        public Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[] include);
    }
}
