using System;
namespace QLCC.Services.Dtos.Leave
{
	public class LeaveUpdateDto
	{
        public int LeaveType { get; set; }
        public DateTime? LeaveDate { get; set; }
        public int ApproveUserId { get; set; }
        public string Reason { get; set; }
    }
}

