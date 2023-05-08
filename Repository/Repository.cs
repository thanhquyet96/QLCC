using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class Repository<TContext, T> : IRepository<TContext, T>, IDisposable where T:class where TContext : DbContext
    {
        
        private bool _isDisposed;
        protected TContext _context;
       
        public Repository(TContext context)
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

            await _context.Set<T>().AddRangeAsync(t);

        }

        public virtual IQueryable<T> Filter(params Expression<Func<T, bool>>[] expressions)
        {
            return _context.Set<T>().WhereMany(expressions);
        }

        public virtual async Task<T> Get(params Expression<Func<T, bool>>[] expressions)
        {
            return await _context.Set<T>().WhereMany(expressions).FirstOrDefaultAsync();
        }

        public virtual IQueryable<T> All()
        {
            return _context.Set<T>().AsQueryable();
        }
        public virtual async Task<T> Find(object id)
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

        public virtual async Task Update(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Entry(t);
        }
        public virtual async Task Delete(object id)
        {
            var entity = await Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Set<T>().Remove(entity);
        }


        public virtual async Task<bool> ContainAsync(Expression<Func<T, bool>> exception)
            
        {
            var model = await _context.Set<T>().Where(exception).ToListAsync();
            return false;
        }

        public virtual async Task FromSql(FormattableString rawSql)
        {
            //_context.Set<T>().FromSql(rawSql);
            _context.Database.ExecuteSql(rawSql);
        }


        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            _isDisposed = true;
        }
    }
}

