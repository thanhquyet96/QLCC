using System;
using System.Linq.Expressions;
using Common;

namespace QLCC.Services.Dtos.HistoryTimeKeep
{
    public class HistoryTimeKeepGridPagingDto : PagingParams<HistoryTimeKeepGridDto>
    {

        //        if (!string.IsNullOrWhiteSpace(keyword))
        //            {
        //                result = result.Where(x => x.NhanVien.FullName.ToLower().Contains(keyword.ToLower())).ToList();
        //    }
        //            if (UserIdentity.OnlyUser)
        //            {
        //                result = result.Where(x => x.USER_ID == UserIdentity.Id).ToList();
        //}
        //x => x.NgayChamCong.Month == month && x.NgayChamCong.Year == year

        public int? Year { get; set; }
        public int? Month { get; set; }
        public string? Keyword { get; set; }
        
        public override List<Expression<Func<HistoryTimeKeepGridDto, bool>>> GetPredicates()
        {
            var predicates = base.GetPredicates();
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                predicates.Add(x => x.UserFullName.Contains(Keyword));
            }

            if (Year != null)
            {
                predicates.Add(x => x.DateTimeKeep.Year == Year.Value);
            }


            if (Month != null)
            {
                predicates.Add(x => x.DateTimeKeep.Month == Month.Value);
            }

            return base.GetPredicates();
        }
    }
}

