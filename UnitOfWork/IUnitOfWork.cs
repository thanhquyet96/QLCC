using System;
namespace UnitOfWork
{
	public interface IUnitOfWork
	{
		Task Save();
	}
}

