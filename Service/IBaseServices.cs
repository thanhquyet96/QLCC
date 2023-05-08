using System.Linq.Expressions;
using Common;
namespace Service;
public interface IBaseServices
{
    Task<TDto> Find<TDto>(object id);
    Task<TDto> Get<TDto>(params Expression<Func<TDto, bool>>[] expression);
    IQueryable<TDto> Filter<TDto>(params Expression<Func<TDto, bool>>[] expression);
    IQueryable<TDto> Filter<TDto>();
    //IQueryable FilterEntity<TEntity, TDto>(params Expression<Func<TEntity, bool>>[] expression);
    Task<PagingResult<TDto>> FilterPage<TDto>(PagingParams<TDto> pagingParams, params Expression<Func<TDto, bool>>[] expression);
    Task Add<TDto>(TDto t);
    Task Update<TDto>(object id,TDto t);
    Task Delete(object id);
    Task<bool> ContainAsync<TDto>(Expression<Func<TDto, bool>> exception);
    Task FromSql(FormattableString rawSql);
}


