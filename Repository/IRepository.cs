using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public interface IRepository<TContext, T> where T:class where TContext:DbContext
    {
		Task<T> Get(object id);
		Task<T> Get(params Expression<Func<T, bool>>[] expression);
        IQueryable Filter(params Expression<Func<T, bool>>[] expression);
		Task Add(T t);
		void Update(T t);
		Task Save();
		Task Delete(object id);
    }
}

