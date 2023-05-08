using System;
using System.Linq.Expressions;
using Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class Repository<T>:IRepository<T> where T : class, IDisposable
    {
        
        private bool _isDisposed;
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
            _isDisposed = false;
        }
        public virtual async Task Add(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _context.Set<T>().AddAsync(t);
        }

        public virtual IQueryable<T> Filter(params Expression<Func<T, bool>>[] expressions)
        {
            return _context.Set<T>().WhereMany(expressions);
        }

        public virtual async Task<T> Get(params Expression<Func<T, bool>>[] expressions)
        {
            return await _context.Set<T>().WhereMany(expressions).FirstOrDefaultAsync();
        }

        public virtual async Task<T> Get(object id)
        {
            
            T entity;
            if (id is object[])
            {

                entity = await _context.Set<T>().FindAsync(id as object[]);
            }
            else
            {
                entity = await _context.Set<T>().FindAsync(id);
            }
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return entity;
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void Update(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Entry(t);
        }
        public virtual async Task Delete(object id)
        {
            var entity = await Get(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Set<T>().Remove(entity);
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            _isDisposed = true;
        }
    }
}

