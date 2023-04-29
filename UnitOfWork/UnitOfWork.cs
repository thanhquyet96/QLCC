using System;
using Microsoft.EntityFrameworkCore;

namespace UnitOfWork
{
	public class UnitOfWork:IUnitOfWork
	{
        private DbContext _context;
		public UnitOfWork(DbContext context)
		{
            _context = context;
		}

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

