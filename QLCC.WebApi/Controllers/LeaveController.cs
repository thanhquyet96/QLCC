using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCC.Data;
using QLCC.Services;
using QLCC.Services.Dtos.Leave;
using QLCC.WebApi.Helpers;
using System.Security.Claims;
using static QLCC.Data.Constants;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveController : BaseController 
    {
        private readonly LeaveServices _leaveServices;

        public LeaveController(IHttpContextAccessor httpContextAccessort, LeaveServices leaveServices) :base (httpContextAccessort)
        {
            _leaveServices = leaveServices;
        }

        // GET: api/Leave
        [HttpGet]
        public async Task<ActionResult> GetLeave([FromQuery] LeaveGridPagingDto pagingDto)
        {
            //var model = await _context.Leave.Include(x=>x.NguoiPheDuyet).Include(x=>x.NhanVien).ToListAsync();
            //if (!string.IsNullOrWhiteSpace(keyword))
            //{
            //    model = model.Where(x => x.NhanVien.FullName.Contains(keyword)).ToList();
            //}
            //if (UserIdentity.OnlyUser)
            //{
            //    model = model.Where(x => x.NhanVienId == UserIdentity.Id).ToList();
            //}
            //var result = model.Select(x => new LeaveDetail()
            //{
            //    Id = x.Id,
            //    LoaiNghi = x.LoaiNghi,
            //    LyDo = x.LyDo,
            //    NguoiPheDuyet = x.NguoiPheDuyet != null ? x.NguoiPheDuyet.FullName : "",
            //    TaoChoNgay = x.TaoChoNgay,
            //    TenNhanVien = x.NhanVien != null ? x.NhanVien.FullName : "",
            //    ThoiGianTao = x.ThoiGianTao,
            //    TrangThai = x.TrangThai,
            //    HinhThucNghi = x.HinhThucNghi,
            //}).ToList();
            var result = await _leaveServices.GetLeaves(pagingDto);
            return Ok(result);
        }

        // GET: api/Leave/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveDetailDto>> GetLeave(int id)
        {
            var leave = await _leaveServices.GetLeave(id);

            if (leave == null)
            {
                return NotFound();
            }

            return leave;
        }

        // PUT: api/Leave/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeave(int id, LeaveUpdateDto leave)
        {
          await  _leaveServices.Update(id, leave);
            return Ok();
        }

        [HttpPut("{id}/update-status")]
        public async Task<IActionResult> UpdateStatus(int id, int status = 1)
        {
            await _leaveServices.UpdateStatus<LeaveUpdateStatusDto>(id, new LeaveUpdateStatusDto() { LeaveStatus = status });
            return Ok();
        }

        // POST: api/Leave
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(PRIVILGE.USER, PRIVILGE.OTHER)]
        public async Task<ActionResult<LeaveCreateDto>> PostLeave([FromBody] LeaveCreateDto leave)
        {
            //var userId = int.Parse(userIdentiy.Claims.First(x => x.Type == "Id").Value);

            //var user = User.Claims.First(x=>x.Type == "id")?.Value;
            //string userId = User.FindFirst(ClaimTypes.Sid)?.Value;
            
            if(UserIdentity != null)
            {
                leave.UserId = UserIdentity.Id;
            }
            await _leaveServices.Add(leave);

            return Ok();
        }

        // DELETE: api/Leave/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeave(int id)
        {
            await _leaveServices.Delete(id);
            return Ok();
        }
    }
}
