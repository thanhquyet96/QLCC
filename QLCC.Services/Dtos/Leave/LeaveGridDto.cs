using System;
using QLCC.Data;
using static QLCC.Data.Constants;

namespace QLCC.Services.Dtos.Leave
{
	public class LeaveGridDto
	{
        //public int Id { get; set; }
        //public int UserId { get; set; }
        //public string UserFullName { get; set; }
        //public int ApproveUserId { get; set; }
        //public string ApproveUserFullName { get; set; }
        //public string Reason { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime CreatedForDay { get; set; }
        ///// <summary>
        ///// Loại nghỉ
        ///// </summary>
        //public LeaveTypeEnum LeaveType { get; set; }
        ///// <summary>
        ///// Hình thức
        ///// </summary>
        //public LeaveFormEnum LeaveForm { get; set; }
        //public LeaveStatusEnum LeaveStatus { get; set; }


        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string ApproveUserFullName { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CreatedForDay { get; set; }
        /// <summary>
        /// Loại nghỉ
        /// </summary>
        //public LeaveTypeEnum LeaveType { get; set; }

        /// <summary>
        /// Hình thức
        /// </summary>
        //public LeaveFormEnum LeaveForm { get; set; }
        //public LeaveStatusEnum LeaveStatus { get; set; }

        /// <summary>
        /// Loại nghỉ
        /// </summary>
        public LeaveTypeEnum? LeaveType { get; set; }
        public string LeaveTypeName
        {
            get
            {
                if (LeaveType.HasValue)
                {
                    switch (LeaveType.Value)
                    {
                        case LeaveTypeEnum.OffFullDay:
                            return LeaveTypeEnum.OffFullDay.GetDescription();
                        case LeaveTypeEnum.OffMorning:
                            return LeaveTypeEnum.OffMorning.GetDescription();
                        case LeaveTypeEnum.OffAfternoon:
                            return LeaveTypeEnum.OffAfternoon.GetDescription();
                        default:
                            return "N/A";
                    }
                }
                return "N/A";
            }
        }
        public LeaveStatusEnum? LeaveStatus { get; set; }
        public string LeaveStatusName
        {
            get
            {
                if (!LeaveStatus.HasValue) return "N/A";
                switch (LeaveStatus.Value)
                {
                    case LeaveStatusEnum.Pending:
                        return LeaveStatusEnum.Pending.GetDescription();
                    case LeaveStatusEnum.Approved:
                        return LeaveStatusEnum.Approved.GetDescription();
                    case LeaveStatusEnum.Reject:
                        return LeaveStatusEnum.Reject.GetDescription();
                    default:
                        return "N/A";
                }
            }
        }

        public LeaveFormEnum? LeaveForm { get; set; }

        public string LeaveFormName
        {
            get
            {
                if (LeaveForm.HasValue)
                {
                    switch (LeaveForm.Value)
                    {
                        case LeaveFormEnum.UnpaidLeave:
                            return LeaveFormEnum.UnpaidLeave.GetDescription();
                            ;
                        case LeaveFormEnum.OnLeave:
                            return LeaveFormEnum.OnLeave.GetDescription();
                        default:
                            return "N/A";
                    }
                }
                return "N/A";
            }
        }

    }
}

