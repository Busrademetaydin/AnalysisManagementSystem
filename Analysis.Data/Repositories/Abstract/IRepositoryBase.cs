using Analysis.Entities.Abstract;
using System.Linq.Expressions;

namespace Analysis.Data.Repositories.Abstract
{
    public interface IRepositoryBase<T, TId> where T : BaseEntity<TId>
    {
        public Task<int> InsertAsync(T entity);
        public Task<int> UpdateAsync(T entity);
        public Task<int> DeleteAsync(T entity);
        public Task<int> DeleteAsync(TId id);

        public Task<T> GetByIdAsync(TId id);
        public Task<T?> Get(Expression<Func<T, bool>> expression);
        public Task<ICollection<T>?> GetAllAsync(Expression<Func<T, bool>>? predicate);

        public Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>>? predicate, params Expression<Func<T, object>>[] include);
    }
}
