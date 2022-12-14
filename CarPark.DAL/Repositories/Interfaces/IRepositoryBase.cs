using System.Linq.Expressions;

namespace CarPark.DAL.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);

        void Delete(T entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);

        Task<T?> GetSingleAsync(object obj);

        Task<T?> GetSingleConditionsAsync(Expression<Func<T, bool>> where);
    }
}