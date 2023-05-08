using System;
using Microsoft.EntityFrameworkCore;

namespace UnitOfWork
{
	public interface IUnitOfWork<TContext> where TContext : DbContext, new()
	{
		Task Save();
	}
}

