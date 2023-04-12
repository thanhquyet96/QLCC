using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLCC.Entities;
using QLCC.Helpers;
using QLCC.Models;
using QLCC.ViewModels;
using static QLCC.ViewModels.Constants;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LichSuChamCongController : BaseController
    {
        private readonly DataContext _context;

        public LichSuChamCongController(IHttpContextAccessor httpContextAccessort, DataContext context): base(httpContextAccessort)
        {
            _context = context;
        }

        // GET: api/LichSuChamCong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LichSuChamCongGrid>>> GetLichSuChamCong(int month, int year, string keyword)
        {
            var result = await _context.LichSuChamCong.Include(x => x.NhanVien).Where(x => x.NgayChamCong.Month == month && x.NgayChamCong.Year == year).ToListAsync();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                result = result.Where(x => x.NhanVien.HoVaTen.ToLower().Contains(keyword.ToLower())).ToList();
            }
            if (UserIdentity.OnlyUser)
            {
                result = result.Where(x => x.NhanVienId == UserIdentity.Id).ToList();
            }
            var data = result.GroupBy(x => new { NhanVienId = x.NhanVienId, HoVaTen = x.NhanVien.HoVaTen });
            List<IDictionary<string, object>> histories = new List<IDictionary<string, object>>();
            foreach (var item in data)
            {

                //Check Nghỉ phép
                var nghiPheps = await _context.NghiPhep.Where(x => x.NhanVienId == item.Key.NhanVienId && x.TaoChoNgay.Year == year && x.TaoChoNgay.Month == month && x.TrangThai == TrangThaiNghiEnum.DaDuyet).ToListAsync();
                //
                var record = new ExpandoObject() as IDictionary<string, object>;
                record.Add("hoVaTen", item.Key.HoVaTen);
                LoaiNghiEnum loaiNghi = LoaiNghiEnum.NghiCaNgay;
                foreach (var day in item)
                {
                    var nghiPhep = nghiPheps.FirstOrDefault(x => x.TaoChoNgay.Date == day.NgayChamCong.Date);
                    if (nghiPhep != null)
                    {
                        if(nghiPhep.HinhThucNghi == HinhThucNghiEnum.NghiPhep && nghiPhep.LoaiNghi == LoaiNghiEnum.NghiCaNgay)
                        {
                            loaiNghi = LoaiNghiEnum.DiLam;
                        }
                        else
                        {
                            loaiNghi = nghiPhep.LoaiNghi;
                        }
                    }
                    else
                    {
                        loaiNghi = LoaiNghiEnum.DiLam;
                    }
                    if (!record.ContainsKey($"heading_{day.NgayChamCong.Day.ToString()}"))
                    {
                        record.Add($"heading_{day.NgayChamCong.Day.ToString()}", (int)loaiNghi);
                    }
                }
                if (nghiPheps != null && !nghiPheps.Any(x => item.Select(x => x.NgayChamCong.Day).Contains(x.TaoChoNgay.Day)))
                {
                    foreach (var nghiPhep in nghiPheps)
                    {
                        if (!record.ContainsKey($"heading_{nghiPhep.TaoChoNgay.Day.ToString()}"))
                        {
                            LoaiNghiEnum stautus = LoaiNghiEnum.NghiCaNgay;
                            if (nghiPhep.HinhThucNghi == HinhThucNghiEnum.NghiPhep && nghiPhep.LoaiNghi == LoaiNghiEnum.NghiCaNgay)
                            {
                                stautus = LoaiNghiEnum.DiLam;
                            }
                            else
                            {
                                stautus = nghiPhep.LoaiNghi;
                            }
                            record.Add($"heading_{nghiPhep.TaoChoNgay.Day.ToString()}", (int)stautus);
                        }
                    }
                }
                int days = DateTime.DaysInMonth(year, month);
                var now = DateTime.Now;
                if (month == now.Month && year == now.Year)
                {
                    for (int i = 1; i <= days; i++)
                    {
                        if (i > now.Day)
                        {
                            if (!record.ContainsKey($"heading_{i}"))
                            {
                                record.Add($"heading_{i}", (int)LoaiNghiEnum.KhongXacDinh);
                            }
                        }
                    }
                }

                histories.Add(record);
            }
            

            return Ok(histories);
        }

        // GET: api/LichSuChamCong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LichSuChamCong>> GetLichSuChamCong(int id)
        {
            var lichSuChamCong = await _context.LichSuChamCong.FindAsync(id);

            if (lichSuChamCong == null)
            {
                return NotFound();
            }

            return lichSuChamCong;
        }
    }
}
