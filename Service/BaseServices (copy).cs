using System;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common;
using Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Repository;
namespace Service
{
	public class BaseServices<TDto, TEntity> :IBaseServices<TDto> where TDto : class where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
		private IMapper _mapper;
		public BaseServices(IRepository<TEntity> repository, IMapper mapper)
		{
            _repository = repository;
			_mapper = mapper;
		}

        public async Task<PagingResult<TDto>> FilterPage(PagingParams<TDto> pagingParams, params Expression<Func<TDto, bool>>[] expressions)
        {
			if(pagingParams == null)
			{
				throw new ArgumentNullException("Paging Params");
			}
			var result = new PagingResult<TDto>() { PageSize = pagingParams.ItemPerPage, PageIndex = pagingParams.PageIndex };
			var filter = pagingParams.GetPredicates();
			IQueryable<TDto> query = _repository.Filter().ProjectTo<TDto>(_mapper.ConfigurationProvider);
			if(pagingParams.SortExpression != null)
			{
				query = query.OrderBy(pagingParams.SortExpression);
			}

			if(filter != null && filter.Any())
			{
				query = query.WhereMany(filter);
			}
			if(expressions != null && expressions.Any())
			{
				query = query.WhereMany(expressions);
			}

			if(pagingParams.StartIndex > 0)
			{
				query = query.Skip(pagingParams.StartIndex);
			}

			if(pagingParams.ItemPerPage > 0)
			{
				query = query.Take(pagingParams.ItemPerPage);
			}
			result.TotalRows = await query.CountAsync();
			result.Data = await query.ToListAsync();
			return result;
        }
    }
}

