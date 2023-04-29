using System.Linq.Expressions;
namespace Common;
public class PagingParams<T>
{
    public static int DefaultPageSize = 10;
    public int PageIndex { get; set; }
    //public int ToltalPage { get; set; } = 0;
    public int ItemPerPage { get; set; }
    public string SortBy { get; set; }
    public bool SortDesc { get; set; }
    //public string SortExpression
    //{
    //    get
    //    {
    //        return (string.IsNullOrEmpty(SortBy) ? "Id" : SortBy) + " " + (SortDesc ? "desc" : "asc");
    //    }
    //}
    public Expression<Func<T, bool>> SortExpression { get; set; }
    public int StartIndex
    {
        get
        {
            return ItemPerPage * (PageIndex - 1);
        }
    }

    public virtual List<Expression<Func<T, bool>>> GetPredicates()
    {
        return new List<Expression<Func<T, bool>>>();
    }
    public PagingParams()
    {
        SortBy = "Id";
        SortDesc = true;
        ItemPerPage = DefaultPageSize;
        PageIndex = 0;
    }
}

