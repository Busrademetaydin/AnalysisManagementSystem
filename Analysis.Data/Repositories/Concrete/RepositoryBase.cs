using Analysis.Data.Repositories.Abstract;
using Analysis.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Analysis.Data.Repositories.Concrete
{
    public class RepositoryBase<T, TId, TContext> : IRepositoryBase<T, TId> where T : BaseEntity<TId>
        where TContext : DbContext, new()
    {
        public readonly TContext db;


        public RepositoryBase()
        {
            db = new TContext();
        }

        public async Task<int> Insert(T entity)
        {
            int sonuc = 0;
            try
            {
                db.Set<T>().AddAsync(entity);
                sonuc = await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync(ex.Message);
            }

            return sonuc;
        }

        public async Task<int> Update(T entity)
        {
            db.Set<T>().Update(entity);
            return await db.SaveChangesAsync();
        }


        public async Task<int> Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(TId id)
        {
            var result = await db.Set<T>().FindAsync(id);

            return await Delete(result);

        }

        public async Task<T?> Get(Expression<Func<T, bool>>? expression)
        {
            if (expression != null)
            {
                return await db.Set<T>().FirstOrDefaultAsync(expression);
            }
            else
            {
                return default(T); // or null depending on your logic
            }
        }
        public async Task<T> GetById(TId id)
        {
            if (id == null)
            {
                return null;
            }
            return await db.Set<T>().FindAsync(id);
        }
        public async Task<ICollection<T>?> GetAll(Expression<Func<T, bool>>? expression = null)
        {
            if (expression != null)
            {
                return await db.Set<T>().Where(expression).ToListAsync();
            }
            else
            {
                return await db.Set<T>().ToListAsync();
            }
        }
        public async Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query;
            if (expression != null)
            {
                query = db.Set<T>().Where(expression);
            }
            else
            {
                query = db.Set<T>();
            }

            return include.Aggregate(query, (current, include) => current.Include(include));
        }
    }
}
