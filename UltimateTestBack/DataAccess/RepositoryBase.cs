using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DataContext _context;

        public RepositoryBase(DataContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll(bool TrackChanges)
        {
            return TrackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool TrackChanges)
        {
            return TrackChanges? _context.Set<T>().Where(expression) : _context.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}