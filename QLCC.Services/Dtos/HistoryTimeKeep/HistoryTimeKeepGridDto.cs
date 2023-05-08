using System;
using static QLCC.Data.Constants;

namespace QLCC.Services.Dtos.HistoryTimeKeep
{
	public class HistoryTimeKeepGridDto
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public decimal TimeTimeKeep { get; set; }
        public DateTime DateTimeKeep { get; set; }
        public int LeaveType { get; set; }
    }
}

