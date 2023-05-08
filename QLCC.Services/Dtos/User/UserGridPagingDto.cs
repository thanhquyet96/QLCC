using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QLCC.Services.Dtos.User
{
    public class UserGridPagingDto:PagingParams<UserGridDto>
    {
        /// <summary>
        /// Thông tin lọc dữ liệu
        /// </summary>
        public string? FilterText { get; set; }

        /// <summary>
        /// Method lọc dữ liệu
        /// </summary>
        /// <returns></returns>
        public override List<Expression<Func<UserGridDto, bool>>> GetPredicates()
        {
            var predicates = base.GetPredicates();

            if (!string.IsNullOrEmpty(FilterText))
            {
                predicates.Add(x => x.UserName.Contains(FilterText));
            }
            return predicates;
        }
    }
}
