using System;
using static QLCC.Data.Constants;

namespace QLCC.Services.Dtos.Leave
{
	public class LeaveCreateDto
	{
        //public int Id { get; set; }
        public int UserId { get; set; }
        public int ApproveUserId { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CreatedForDay { get; set; }
        /// <summary>
        /// Loại nghỉ
        /// </summary>
        public LeaveTypeEnum LeaveType { get; set; }
        /// <summary>
        /// Hình thức
        /// </summary>
        public LeaveFormEnum LeaveForm { get; set; }
        public LeaveStatusEnum LeaveStatus { get; set; }
    }
}

