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
	public class BaseServices<TContext,TEntity> :IBaseServices where TEntity : class where TContext:DbContext
    {
        private readonly IRepository<TContext, TEntity> _repository;
		private IMapper _mapper;
		public BaseServices(IRepository<TContext, TEntity> repository, IMapper mapper)
		{
            _repository = repository;
			_mapper = mapper;
		}

        public async Task Add<TDto>(TDto dto)
        {
            var entity = _mapper.Map<TDto, TEntity>(dto);
            await _repository.Add(entity);
        }

        public Task Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable Filter<TDto>(params Expression<Func<TDto, bool>>[] expessions)
        {
            return _repository.Filter().ProjectTo<TDto>(_mapper.ConfigurationProvider).WhereMany(expessions);
        }

        

        public Task<TDto> Get<TDto, TEntity1>(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<TDto> Get<TDto>(params Expression<Func<TDto, bool>>[] expression)
        {
            var entity = await _repository.Get(expression);
            return _mapper.Map<TEntity, TDto>(entity);
        }

        public Task<TDto> Get<TDto>(object id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Update<TDto1>(TDto1 t)
        {
            throw new NotImplementedException();
        }


        //public async Task<PagingResult<TDto>> FilterPage(PagingParams<TDto> pagingParams, params Expression<Func<TDto, bool>>[] expressions)
        //{
        //    if (pagingParams == null)
        //    {
        //        throw new ArgumentNullException("Paging Params");
        //    }
        //    var result = new PagingResult<TDto>() { PageSize = pagingParams.ItemPerPage, PageIndex = pagingParams.PageIndex };
        //    var filter = pagingParams.GetPredicates();
        //    IQueryable<TDto> query = _repository.Filter().ProjectTo<TDto>(_mapper.ConfigurationProvider);
        //    if (pagingParams.SortExpression != null)
        //    {
        //        query = query.OrderBy(pagingParams.SortExpression);
        //    }

        //    if (filter != null && filter.Any())
        //    {
        //        query = query.WhereMany(filter);
        //    }
        //    if (expressions != null && expressions.Any())
        //    {
        //        query = query.WhereMany(expressions);
        //    }

        //    if (pagingParams.StartIndex > 0)
        //    {
        //        query = query.Skip(pagingParams.StartIndex);
        //    }

        //    if (pagingParams.ItemPerPage > 0)
        //    {
        //        query = query.Take(pagingParams.ItemPerPage);
        //    }
        //    result.TotalRows = await query.CountAsync();
        //    result.Data = await query.ToListAsync();
        //    return result;
        //}
    }
}

