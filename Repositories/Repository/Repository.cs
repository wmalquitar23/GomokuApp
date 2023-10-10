using GomokuApp.Data;
using GomokuApp.Repositories.Interface;
using System.Linq.Expressions;

namespace GomokuApp.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly DBContext Context;
        public Repository(DBContext context)
        {
            Context = context;
        }
        public virtual void Add(T entity)
        {
            Context.Set<T>().AddAsync(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRangeAsync(entities);
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual T GetById(int Id)
        {
            return Context.Set<T>().Find(Id);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }
    }
}
