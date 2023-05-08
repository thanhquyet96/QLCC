using System;
using System.Linq.Expressions;
using Common;

namespace QLCC.Services.Dtos.Leave
{
	public class LeaveGridPagingDto: PagingParams<LeaveGridDto>
    {
        public string? Keyword { get; set; }
        public override List<Expression<Func<LeaveGridDto, bool>>> GetPredicates()
        {
            var predicates = base.GetPredicates();
            if(Keyword != null)
            {
                predicates.Add(x => x.UserFullName.Contains(Keyword));
            }
            return base.GetPredicates();
        }
    }
}

