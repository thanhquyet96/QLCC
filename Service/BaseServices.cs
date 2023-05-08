using System;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common;
using Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Linq.Dynamic.Core;

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

        public async Task Delete(object id)
        {
            await _repository.Delete(id);
        }

        public IQueryable<TDto> Filter<TDto>()
        {
            return _repository.Filter().ProjectTo<TDto>(_mapper.ConfigurationProvider);
        }

        public IQueryable<TDto> Filter<TDto>(params Expression<Func<TDto, bool>>[] expessions)
        {
            return _repository.Filter().ProjectTo<TDto>(_mapper.ConfigurationProvider).WhereMany(expessions);
        }

        public async Task<TDto> Find<TDto>(object id)
        {
            var entity = await _repository.Find(id);
            return _mapper.Map<TEntity, TDto>(entity);
        }

        public async Task<TDto> Get<TDto>(params Expression<Func<TDto, bool>>[] expression)
        {
            return await _repository.All().ProjectTo<TDto>(_mapper.ConfigurationProvider).WhereMany(expression).FirstOrDefaultAsync();
        }

        public async Task Update<TDto>(object id,TDto t)
        {
            var entity = await _repository.Find(id);
            _mapper.Map<TDto, TEntity>(t, entity);
            await _repository.Update(entity);
        }

        public virtual async Task<bool> ContainAsync<TDto>(Expression<Func<TDto, bool>> exception)
        {
            //var item = await _repository.Filter().ProjectTo<TDto>(_mapper.ConfigurationProvider).Where(exception).ToListAsync();

            var model = await _repository.Filter().ProjectTo<TDto>(_mapper.ConfigurationProvider).Where(exception).ToListAsync();

            return model.Any() ;
        }


        public async Task<PagingResult<TDto>> FilterPage<TDto>(PagingParams<TDto> pagingParams, params Expression<Func<TDto, bool>>[] expressions)
        {
            if (pagingParams == null)
            {
                throw new ArgumentNullException("Paging Params");
            }
            var result = new PagingResult<TDto>() { PageSize = pagingParams.ItemPerPage, PageIndex = pagingParams.PageIndex };
            var filter = pagingParams.GetPredicates();
            IQueryable<TDto> query = _repository.Filter().ProjectTo<TDto>(_mapper.ConfigurationProvider);
            if (pagingParams.SortExpression != null)
            {
                query = query.OrderBy(pagingParams.SortExpression);
            }

            if (filter != null && filter.Any())
            {
                query = query.WhereMany(filter);
            }
            if (expressions != null && expressions.Any())
            {
                query = query.WhereMany(expressions);
            }

            if (pagingParams.StartIndex > 0)
            {
                query = query.Skip(pagingParams.StartIndex);
            }

            if (pagingParams.ItemPerPage > 0)
            {
                query = query.Take(pagingParams.ItemPerPage);
            }
            result.TotalRows = await query.CountAsync();
            result.Data = await query.ToListAsync();
            return result;
        }

        public async Task FromSql(FormattableString rawSql)
        {
            await _repository.FromSql(rawSql);
        }

    }
}

