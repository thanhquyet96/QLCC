using System;
using System.Linq.Expressions;
using Common;

namespace QLCC.Services.Dtos.Role
{
	public class RoleGridPagingDto: PagingParams<RoleGridDto>
	{
        public string? Keyword { get; set; }
        public override List<Expression<Func<RoleGridDto, bool>>> GetPredicates()
        {
            var predicates = base.GetPredicates();
            if(Keyword != null)
            {
                predicates.Add(x => x.Name.Contains(Keyword));
            }
            return base.GetPredicates();
        }
    }
}

