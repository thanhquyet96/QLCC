using System;
using static QLCC.Data.Constants;

namespace QLCC.Services.Dtos.HistoryTimeKeep
{
	public class HistoryTimeKeepInfoDto
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public decimal TimeTimeKeep { get; set; }
        public DateTime DateTimeKeep { get; set; }
        public LeaveTypeEnum LeaveType { get; set; }
    }
}

