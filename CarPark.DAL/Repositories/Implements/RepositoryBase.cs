using CarPark.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarPark.DAL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly CarParkContext _context;

        public RepositoryBase(CarParkContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetSingleAsync(object obj)
        {
            return await _context.Set<T>().FindAsync(obj);
        }

        public virtual async Task<T?> GetSingleConditionsAsync(Expression<Func<T, bool>> where)
        {
            return await _context.Set<T>().Where(where).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where)
        {
            return await _context.Set<T>().Where(where).ToListAsync();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        //public async Task Update(T entity)
        //{
        //    _context.Set<T>().Attach(entity);
        //    _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //}
    }
}