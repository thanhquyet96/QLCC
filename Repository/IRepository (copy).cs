using System;
using System.Linq.Expressions;

namespace Repository
{
	public interface IRepository
    {
		Task Get<T>(object id);
		Task Get<T>(params Expression<Func<T, bool>>[] expression);
        IQueryable Filter<T>(params Expression<Func<T, bool>>[] expression);
		Task Add<T>(T t);
		void Update<T>(T t);
		Task Save();
		Task Delete(object id);
    }
}

