using System;
using System.Linq.Expressions;

namespace Common.Helpers
{
	public static class ExpressionHelper
	{

		public static IQueryable<T> WhereMany<T>(this IQueryable<T> source, params Expression<Func<T, bool>>[] expessions)
		{
			if(expessions != null && expessions.Any())
			{
				foreach (var exp in expessions)
				{
					source.Where(exp);
				}
			}
            return source;
        }
		public static IQueryable<T> WhereMany<T>(this IQueryable<T> source, IEnumerable<Expression<Func<T, bool>>> expressions)
		{
			return source.WhereMany(expressions);
		}
    }
}

