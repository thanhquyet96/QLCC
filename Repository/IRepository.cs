using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public interface IRepository<TContext, T> where T:class where TContext:DbContext
    {
		Task<T> Find(object id);
		Task<T> Get(params Expression<Func<T, bool>>[] expression);
        IQueryable<T> Filter(params Expression<Func<T, bool>>[] expression);
		IQueryable<T> All();
		Task Add(T t);
		Task Update(T t);
		Task Delete(object id);
		Task<bool> ContainAsync(Expression<Func<T, bool>> exception);
		Task FromSql(FormattableString rawSql);
    }
}

