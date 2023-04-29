using System.Linq.Expressions;
using Common;
namespace Service;
public interface IBaseServices
{
    Task<TDto> Get<TDto>(object id);
    Task<TDto> Get<TDto>(params Expression<Func<TDto, bool>>[] expression);
    IQueryable Filter<TDto>(params Expression<Func<TDto, bool>>[] expression);
    Task<PagingResult<TDto>> FilterPage<TDto>(PagingParams<TDto> pagingParams, params Expression<Func<TDto, bool>>[] expression);
    Task Add<TDto>(TDto t);
    void Update<TDto>(TDto t);
    Task Save();
    Task Delete(object id);
}

