using System;
using System.Linq.Expressions;
using Common;

namespace QLCC.Services.Dtos.UserRole
{
	public class UserRoleGridPagingDto:PagingParams<UserRoleGridDto>
	{
        public override List<Expression<Func<UserRoleGridDto, bool>>> GetPredicates()
        {
            return base.GetPredicates();
        }
    }
}

