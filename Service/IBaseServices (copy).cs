using System.Linq.Expressions;
using Common;
namespace Service;
public interface IBaseServices<TDto> where TDto : class
{
    Task<PagingResult<TDto>> FilterPage(PagingParams<TDto> pagingParams, params Expression<Func<TDto, bool>>[] expression);

}

