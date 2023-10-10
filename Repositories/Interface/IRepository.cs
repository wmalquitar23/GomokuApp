using System.Linq.Expressions;

namespace GomokuApp.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
    }
}
