using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QLCC.Data;
using QLCC.Data.Entities;
using QLCC.Services.Dtos.DateTimeKeep;
using QLCC.Services.Dtos.HistoryTimeKeep;
using QLCC.Services.Dtos.TimeKeep;
using QLCC.Services.Dtos.User;
using Repository;
using UnitOfWork;

namespace QLCC.Services
{
    public class TimeKeepServices : QLCCBaseServices<TIME_KEEP>
    {
        private readonly DateTimeKeepServices _dateTimeKeepServices;
        private readonly HistoryTimeKeepServices _historyTimeKeepServices;
        private readonly UserServices _userServices;
        public TimeKeepServices(IRepository<QLCCContext, TIME_KEEP> repository, IMapper mapper, ILogger<QLCCBaseServices<TIME_KEEP>> logger, IUnitOfWork<QLCCContext> unitOfWork, DateTimeKeepServices dateTimeKeepServices, HistoryTimeKeepServices historyTimeKeepServices, UserServices userServices) : base(repository, mapper, logger, unitOfWork)
        {
            _dateTimeKeepServices = dateTimeKeepServices;
            _historyTimeKeepServices = historyTimeKeepServices;
            _userServices = userServices;
        }
        public async Task CheckInOut(int userId)
        {
            // CheckIn
            try
            {
                // Thêm thời gian chấm công
                var dateNow = DateTime.Now;
                var ngayChamCong = new DateTimeKeepCreateDto()
                {
                    TimeCheckIn = dateNow,
                    TimeCheckOut = dateNow,
                    Date = dateNow,
                };
                await _dateTimeKeepServices.Add<DateTimeKeepCreateDto>(ngayChamCong);
                //await _context.NgayChamCong.AddAsync(ngayChamCong);

                // Thêm Thời gian chấm công cho người chấm công
                var chamCong = new TimeKeepCreateDto()
                {
                    UserId = userId,
                    DateTimeKeepId = ngayChamCong.Id,
                };
                // Kiểm tra nhân viên và thời gian đó đã tồn tại hay chưa
                var chamCongOl = await base.Get<TimeKeepInfoDto>(x => x.UserId == chamCong.UserId && x.DateTimeKeepId == chamCong.DateTimeKeepId);
                // Chưa tồn tại
                if (chamCongOl == null)
                {
                    // THêm vào db
                    await base.Add<TimeKeepCreateDto>(chamCong);
                    //await _context.SaveChangesAsync();
                }
                // Lưu lịch sử cho nhân viên chấm công
                var lichsuChamCong = new HistoryTimeKeepCreateDto()
                {
                    DateTimeKeep = dateNow,
                    UserId = userId,
                    //ThoiGianChamCong = null,
                };
                // Kiểm tra lịch sử chấm công đã tồn tại chưa
                var lichsuChamCongOld = await _historyTimeKeepServices.Get<HistoryTimeKeepInfoDto>(x => x.DateTimeKeep.Date == lichsuChamCong.DateTimeKeep.Date && x.UserId == lichsuChamCong.UserId);
                // CHưa tồn tại
                if (lichsuChamCongOld == null)
                {
                    await _historyTimeKeepServices.Add<HistoryTimeKeepCreateDto>(lichsuChamCong);
                    //await _context.SaveChangesAsync();
                }
                await _unitOfWork.Save();
            }
            catch (Exception e)
            {
                
            }
        }

        public async Task<bool> IsCheckIn(int userId)
        {
            var day = DateTime.Now;
            // Kiểm tra nhân viên đã checkin chưa
            try
            {
                var timeKeep = await base.Get<TimeKeepInfoDto>(x => x.UserId == userId && x.DateTimeKeepDate.Date == day.Date);
                return timeKeep != null;

            }
            catch (Exception ex)
            {

            }
            // Chưa checkin
            return false;
        }

        public async Task<List<PayrollInfoDto>> PayRoll(int? year, int? month, int? userId = null)
        {
            year = year ?? DateTime.Now.Year;
            month = month ?? DateTime.Now.Month;
            List<PayrollInfoDto> payrollViews = new List<PayrollInfoDto>();
            //var nhanViens = await _context.Users.Include(x => x.NghiPheps).Include(x => x.ChamCongs).AsNoTracking().ToListAsync();
            var nhanViens = await _userServices.Filter<UserInfoDto>().ToListAsync();
            if (userId != null)
            {
                nhanViens = nhanViens.Where(x => x.Id == userId.Value).ToList();
            }
            foreach (var nhanVien in nhanViens)
            {
                // Lấy danh sách chấm công của nhân viên
                //var chamCongs = await _context.ChamCong.Include(x => x.DATE_TIME_KEEP).Where(x => x.NhanVienId == nhanVien.Id && x.DATE_TIME_KEEP.Date.Month == month && x.DATE_TIME_KEEP.Date.Year == year).AsNoTracking().ToListAsync();
                var chamCongs = await base.Filter<TimeKeepInfoDto>(x => x.UserId == nhanVien.Id && x.DateTimeKeepDate.Month == month && x.DateTimeKeepDate.Year == year).AsNoTracking().ToListAsync();

                var chamCongGroup = chamCongs?.GroupBy(x => x.DateTimeKeepName).Select(z => new
                {
                    NgayChamCong = z.Key,
                    Min = z.Min(t => t.DateTimeKeepTimeCheckIn),
                    Max = z.Max(t => t.DateTimeKeepTimeCheckIn),
                }).ToList();

                var luong = (decimal?)nhanVien.CoefficientsSalary * nhanVien.Salary;
                int days = DateTime.DaysInMonth(year.Value, month.Value);
                var luongInDay = luong / days;
                var logNghiPheps = nhanVien.LeaveInfoDto?.Where(x => x.LeaveStatus == Constants.LeaveStatusEnum.Approved && x.CreatedForDay.Month == month && x.CreatedForDay.Year == year);
                var soNgayNghiPheps = logNghiPheps?.Where(x => x.LeaveForm == Constants.LeaveFormEnum.OnLeave);
                var soNgayNghiPhep1Ngay = soNgayNghiPheps?.Where(x => x.LeaveType == Constants.LeaveTypeEnum.OffFullDay).Count();
                var soNgayNghiPhepNuaNgay = soNgayNghiPheps?.Where(x => x.LeaveForm == Constants.LeaveFormEnum.OnLeave && (x.LeaveType == Constants.LeaveTypeEnum.OffMorning || x.LeaveType == Constants.LeaveTypeEnum.OffAfternoon)).Count();
                var soNgayNghiNuaNgayKhongLuong = logNghiPheps?.Where(x => x.LeaveForm == Constants.LeaveFormEnum.UnpaidLeave && (x.LeaveType == Constants.LeaveTypeEnum.OffMorning || x.LeaveType == Constants.LeaveTypeEnum.OffAfternoon)).Count();

                var nghiKhongLuong = logNghiPheps?.Where(x => x.LeaveForm == Constants.LeaveFormEnum.UnpaidLeave);
                var soNgayNghiKhongLuong = nghiKhongLuong?.Count();

                var tongNghiPhep = (decimal?)luongInDay * (decimal?)(soNgayNghiPhep1Ngay + soNgayNghiPhepNuaNgay / 2) ?? 0;

                //List<IDictionary<string, object>> dataDetail = new List<IDictionary<string, object>>();
                var dataItem = new Dictionary<string, object>();

                decimal? luongThang = 0;
                int tongNgayChamCong = 0;
                if(chamCongGroup != null)
                {
                    foreach (var chamCong in chamCongGroup)
                    {
                        // Lấy thời gian checkIn
                        var timeCheckIn = chamCong.Min;
                        var timeCheckOut = chamCong.Max;
                        var subTime = timeCheckOut - timeCheckIn;
                        // Check nếu đi muộn hơn 15p
                        if (timeCheckIn.Minute > 15)
                        {
                            // trừ 1/3 ngày công
                            luongThang += (luongInDay - (decimal?)(luongInDay / 3));
                            // Thêm ngày đi muộn vào chi tiết
                            dataItem.Add(chamCong.NgayChamCong.ToString(), $"Đi muộn {timeCheckIn.Minute} phút.");
                        }
                        else
                        {
                            luongThang += luongInDay;
                        }
                    }
                    tongNgayChamCong = chamCongGroup.Count();
                }
                if (logNghiPheps != null)
                {
                    foreach (var item in logNghiPheps)
                    {
                        dataItem.Add(item.CreatedForDay.ToString("dd-MM-yyyy"), $"{item.LeaveType.GetDescription()} - {item.LeaveForm.GetDescription()}.");
                    }
                }

                for (int i = 1; i <= days; i++)
                {
                    if (logNghiPheps != null && logNghiPheps.Any(x => x.CreatedForDay.Day == i) || chamCongs != null && chamCongs.Any(x => x.DateTimeKeepDate.Date.Day == i))
                    {
                        continue;
                    }
                    dataItem.Add(new DateTime(year.Value, month.Value, i).ToString("dd-MM-yyyy"), $"Nghỉ không lương.");
                }
                var ngayKhongLuong = days - (soNgayNghiPhep1Ngay ?? 0) - (double)((soNgayNghiPhepNuaNgay ?? 0) / 2) - (double)tongNgayChamCong - (double)((soNgayNghiNuaNgayKhongLuong ?? 0) / 2);
                var model = new PayrollInfoDto()
                {
                    CoefficientsSalary = nhanVien.CoefficientsSalary ?? 0,
                    FullName = nhanVien.FullName,
                    OnLeave = (soNgayNghiPhep1Ngay + soNgayNghiPhepNuaNgay / 2) ?? 0,
                    UnpaidLeave = ngayKhongLuong,
                    SUnpaidLeave = $"{ngayKhongLuong}/{days}",
                    Salary = (luongThang + tongNghiPhep) ?? 0,
                    ValuePairs = dataItem.OrderBy(x => x.Key).ToDictionary(obj => obj.Key, obj => obj.Value)
                };
                payrollViews.Add(model);
            }
            return payrollViews;
        }
    }
}

