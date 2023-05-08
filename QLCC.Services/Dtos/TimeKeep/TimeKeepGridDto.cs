using System;
using System.Linq.Expressions;
using Common;

namespace QLCC.Services.Dtos.TimeKeep
{
	public class TimeKeepGridDto:PagingParams<TimeKeepGridDto>
	{

        public override List<Expression<Func<TimeKeepGridDto, bool>>> GetPredicates()
        {
            return base.GetPredicates();
        }
    }
}

