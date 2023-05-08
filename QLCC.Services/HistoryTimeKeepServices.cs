using System;
using System.Dynamic;
using AutoMapper;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QLCC.Data;
using QLCC.Data.Entities;
using QLCC.Services.Dtos.HistoryTimeKeep;
using QLCC.Services.Dtos.Leave;
using Repository;
using UnitOfWork;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static QLCC.Data.Constants;

namespace QLCC.Services
{
    public class HistoryTimeKeepServices : QLCCBaseServices<HISTORY_TIME_KEEP>
    {
        private readonly LeaveServices _leaveServices;
        public HistoryTimeKeepServices(IRepository<QLCCContext, HISTORY_TIME_KEEP> repository, IMapper mapper, ILogger<QLCCBaseServices<HISTORY_TIME_KEEP>> logger, IUnitOfWork<QLCCContext> unitOfWork, LeaveServices leaveServices) : base(repository, mapper, logger, unitOfWork)
        {
            _leaveServices = leaveServices;
        }


        public async Task<List<IDictionary<string, object>>> GetHistoryTimeKeeps(HistoryTimeKeepGridPagingDto pagingParams)
        {
            var result = await base.FilterPage<HistoryTimeKeepGridDto>(pagingParams);
            //if (!string.IsNullOrWhiteSpace(keyword))
            //{
            //    result = result.Where(x => x.NhanVien.FullName.ToLower().Contains(keyword.ToLower())).ToList();
            //}
            //if (UserIdentity.OnlyUser)
            //{
            //    result = result.Where(x => x.USER_ID == UserIdentity.Id).ToList();
            //}
            var data = result.Data.GroupBy(x => new { UserId = x.UserId, FullName = x.UserFullName });
            List<IDictionary<string, object>> histories = new List<IDictionary<string, object>>();
            foreach (var item in data)
            {

                //Check Nghỉ phép
                var nghiPheps = await _leaveServices.Filter<LeaveInfoDto>(x => x.UserId == item.Key.UserId && x.CreatedForDay.Year == pagingParams.Year && x.CreatedForDay.Month == pagingParams.Month && x.LeaveStatus == Constants.LeaveStatusEnum.Approved).ToListAsync();
                //
                var record = new ExpandoObject() as IDictionary<string, object>;
                record.Add("fullName", item.Key.FullName);
                LeaveTypeEnum loaiNghi = LeaveTypeEnum.OffFullDay;
                foreach (var day in item)
                {
                    var nghiPhep = nghiPheps.FirstOrDefault(x => x.CreatedForDay.Date == day.DateTimeKeep.Date);
                    if (nghiPhep != null)
                    {
                        if (nghiPhep.LeaveForm == LeaveFormEnum.OnLeave && nghiPhep.LeaveType == LeaveTypeEnum.OffFullDay)
                        {
                            loaiNghi = LeaveTypeEnum.FullDay;
                        }
                        else
                        {
                            loaiNghi = nghiPhep.LeaveType;
                        }
                    }
                    else
                    {
                        loaiNghi = LeaveTypeEnum.FullDay;
                    }
                    if (!record.ContainsKey($"heading_{day.DateTimeKeep.Day.ToString()}"))
                    {
                        record.Add($"heading_{day.DateTimeKeep.Day.ToString()}", (int)loaiNghi);
                    }
                }
                if (nghiPheps != null && !nghiPheps.Any(x => item.Select(x => x.DateTimeKeep.Day).Contains(x.CreatedForDay.Day)))
                {
                    foreach (var nghiPhep in nghiPheps)
                    {
                        if (!record.ContainsKey($"heading_{nghiPhep.CreatedForDay.Day.ToString()}"))
                        {
                            LeaveTypeEnum stautus = LeaveTypeEnum.OffFullDay;
                            if (nghiPhep.LeaveForm == LeaveFormEnum.OnLeave && nghiPhep.LeaveType == LeaveTypeEnum.OffFullDay)
                            {
                                stautus = LeaveTypeEnum.FullDay;
                            }
                            else
                            {
                                stautus = nghiPhep.LeaveType;
                            }
                            record.Add($"heading_{nghiPhep.CreatedForDay.Day.ToString()}", (int)stautus);
                        }
                    }
                }
                int days = DateTime.DaysInMonth(pagingParams.Year.Value, pagingParams.Month.Value);
                var now = DateTime.Now;
                if (pagingParams.Month.Value == now.Month && pagingParams.Year.Value == now.Year)
                {
                    for (int i = 1; i <= days; i++)
                    {
                        if (i > now.Day)
                        {
                            if (!record.ContainsKey($"heading_{i}"))
                            {
                                record.Add($"heading_{i}", (int)LeaveTypeEnum.Orther);
                            }
                        }
                    }
                }

                histories.Add(record);
            }

            return histories;
        }
    }
}

