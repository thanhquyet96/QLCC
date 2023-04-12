using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCC.Entities;
using QLCC.Helpers;
using QLCC.Models;
using QLCC.ViewModels;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChamCongController : BaseController
    {
        private readonly DataContext _context;

        public ChamCongController(IHttpContextAccessor httpContextAccessort, DataContext context) : base(httpContextAccessort)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostChamCong([FromQuery] bool checkOut = false)
        {
            // CheckIn
            try
            {
                // Thêm thời gian chấm công
                var dateNow = DateTime.Now;
                var ngayChamCong = new NgayChamCong()
                {
                    ThoiGianChamCong = dateNow,
                    ThoiGianRaVe = dateNow,
                    Ten = dateNow.ToString("dd-MM-yyyy"),
                    Date = dateNow,
                };

                await _context.NgayChamCong.AddAsync(ngayChamCong);
                await _context.SaveChangesAsync();
                // Thêm Thời gian chấm công cho người chấm công
                var chamCong = new ChamCong()
                {
                    NhanVienId = UserIdentity.Id,
                    NgayChamCongId = ngayChamCong.Id,
                };
                // Kiểm tra nhân viên và thời gian đó đã tồn tại hay chưa
                var chamCongOl = await _context.ChamCong.FirstOrDefaultAsync(x => x.NhanVienId == chamCong.NhanVienId && x.NgayChamCongId == chamCong.NgayChamCongId);
                // Chưa tồn tại
                if (chamCongOl == null)
                {
                    // THêm vào db
                    await _context.ChamCong.AddAsync(chamCong);
                    await _context.SaveChangesAsync();
                }
                // Lưu lịch sử cho nhân viên chấm công
                var lichsuChamCong = new LichSuChamCong()
                {
                    NgayChamCong = dateNow,
                    NhanVienId = UserIdentity.Id,
                    //ThoiGianChamCong = null,
                };
                // Kiểm tra lịch sử chấm công đã tồn tại chưa
                var lichsuChamCongOld = await _context.LichSuChamCong.FirstOrDefaultAsync(x => x.NgayChamCong.Date == lichsuChamCong.NgayChamCong.Date && x.NhanVienId == lichsuChamCong.NhanVienId);
                // CHưa tồn tại
                if (lichsuChamCongOld == null)
                {
                    await _context.LichSuChamCong.AddAsync(lichsuChamCong);
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        // Kiểm tra nhân viên đã CheckIn chưa
        [HttpGet("is-checkin")]
        public async Task<ActionResult> IsCheckIn()
        {
            var day = DateTime.Now;
            // Kiểm tra nhân viên đã checkin chưa
            var chamCong = await _context.ChamCong.Include(x => x.NgayChamCong).FirstOrDefaultAsync(x => x.NhanVienId == UserIdentity.Id && x.NgayChamCong.Date.Date == day.Date);
            // Chưa checkin
            return Ok(chamCong != null);
        }

        // Tính lương nhân viên
        [HttpPost("payroll")]
        public async Task<ActionResult> Payroll(int? year, int? month)
        {
            year = year ?? DateTime.Now.Year;
            month = month ?? DateTime.Now.Month;
            List<PayrollViewModel> payrollViews = new List<PayrollViewModel>();
            var nhanViens = await _context.Users.Include(x => x.NghiPheps).Include(x => x.ChamCongs).AsNoTracking().ToListAsync();
            if (UserIdentity.OnlyUser)
            {
                nhanViens = nhanViens.Where(x => x.Id == UserIdentity.Id).ToList();
            }
            foreach (var nhanVien in nhanViens)
            {
                // Lấy danh sách chấm công của nhân viên
                var chamCongs = await _context.ChamCong.Include(x => x.NgayChamCong).Where(x => x.NhanVienId == nhanVien.Id && x.NgayChamCong.Date.Month == month && x.NgayChamCong.Date.Year == year).AsNoTracking().ToListAsync();

                var chamCongGroup = chamCongs?.GroupBy(x => x.NgayChamCong.Ten).Select(z => new
                {
                    NgayChamCong = z.Key,
                    Min = z.Min(t => t.NgayChamCong.ThoiGianChamCong),
                    Max = z.Max(t => t.NgayChamCong.ThoiGianChamCong),
                }).ToList();

                var luong = (decimal)nhanVien.HeSoLuong * nhanVien.LuongCoBan;
                int days = DateTime.DaysInMonth(year.Value, month.Value);
                var luongInDay = luong / days;
                var logNghiPheps = nhanVien.NghiPheps.Where(x => x.TrangThai == Constants.TrangThaiNghiEnum.DaDuyet && x.TaoChoNgay.Month == month && x.TaoChoNgay.Year == year);
                var soNgayNghiPheps = logNghiPheps?.Where(x => x.HinhThucNghi == Constants.HinhThucNghiEnum.NghiPhep);
                var soNgayNghiPhep1Ngay = soNgayNghiPheps?.Where(x => x.LoaiNghi == Constants.LoaiNghiEnum.NghiCaNgay).Count();
                var soNgayNghiPhepNuaNgay = soNgayNghiPheps?.Where(x => x.HinhThucNghi == Constants.HinhThucNghiEnum.NghiPhep && (x.LoaiNghi == Constants.LoaiNghiEnum.NghiSang || x.LoaiNghi == Constants.LoaiNghiEnum.NghiChieu)).Count();
                var soNgayNghiNuaNgayKhongLuong = logNghiPheps?.Where(x => x.HinhThucNghi == Constants.HinhThucNghiEnum.NghiKhongLuong && (x.LoaiNghi == Constants.LoaiNghiEnum.NghiSang || x.LoaiNghi == Constants.LoaiNghiEnum.NghiChieu)).Count();

                var nghiKhongLuong = logNghiPheps?.Where(x => x.HinhThucNghi == Constants.HinhThucNghiEnum.NghiKhongLuong);
                var soNgayNghiKhongLuong = nghiKhongLuong.Count();

                var tongNghiPhep = (decimal?)luongInDay * (decimal?)(soNgayNghiPhep1Ngay + soNgayNghiPhepNuaNgay / 2) ?? 0;

                //List<IDictionary<string, object>> dataDetail = new List<IDictionary<string, object>>();
                var dataItem = new Dictionary<string, object>();

                decimal? luongThang = 0;
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
                        luongThang += (luongInDay - (decimal)(luongInDay / 3));
                        // Thêm ngày đi muộn vào chi tiết
                        dataItem.Add(chamCong.NgayChamCong.ToString(), $"Đi muộn {timeCheckIn.Minute} phút.");
                    }
                    else
                    {
                        luongThang += luongInDay;
                    }

                }

                foreach (var item in logNghiPheps)
                {
                    dataItem.Add(item.TaoChoNgay.Date.ToString("dd-MM-yyyy"), $"{item.LoaiNghi.GetDescription()} - {item.HinhThucNghi.GetDescription()}.");
                }

                for (int i = 1; i <= days; i++)
                {
                    if (logNghiPheps.Any(x => x.TaoChoNgay.Day == i) || chamCongs.Any(x => x.NgayChamCong.Date.Day == i))
                    {
                        continue;
                    }
                    dataItem.Add(new DateTime(year.Value, month.Value, i).ToString("dd-MM-yyyy"), $"Nghỉ không lương.");
                }
                var ngayKhongLuong = days - soNgayNghiPhep1Ngay - (double)soNgayNghiPhepNuaNgay / 2 - chamCongGroup.Count() - (double)soNgayNghiNuaNgayKhongLuong / 2;
                var model = new PayrollViewModel()
                {
                    HeSoLuong = nhanVien.HeSoLuong.Value,
                    HoVaTen = nhanVien.HoVaTen,
                    SoNgayNghiHuongLuong = (soNgayNghiPhep1Ngay + soNgayNghiPhepNuaNgay / 2) ?? 0,
                    SoNgayNghiKhongHuongLuong = ngayKhongLuong ?? 0,
                    TienLuong = (luongThang + tongNghiPhep) ?? 0,
                    ValuePairs = dataItem.OrderBy(x => x.Key).ToDictionary(obj => obj.Key, obj => obj.Value)
                };
                payrollViews.Add(model);
            }
            return Ok(payrollViews);
        }

    }
}
