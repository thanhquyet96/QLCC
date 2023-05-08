using System;
using System.Linq.Expressions;
using Common;

namespace QLCC.Services.Dtos.DateTimeKeep
{
	public class DateTimeKeepGridPagingDto: PagingParams<DateTimeKeepGridDto>
	{

        public override List<Expression<Func<DateTimeKeepGridDto, bool>>> GetPredicates()
        {
            var predicates = base.GetPredicates();
            return base.GetPredicates();
        }
    }
}

