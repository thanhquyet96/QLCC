using System;
namespace Common
{
	public class PagingResult<T>
	{
        public int PageIndex { get; set; } = 0;
        public int TotalRows { get; set; } = 0;
        public int PageSize { get; set; } = 10;
		public List<T> Data { get; set; }
    }
}

