using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCC.Entities;
using QLCC.Helpers;
using QLCC.Models;
using QLCC.ViewModels;
using System.Security.Claims;
using static QLCC.ViewModels.Constants;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NghiPhepController : BaseController 
    {
        private readonly DataContext _context;

        public NghiPhepController(IHttpContextAccessor httpContextAccessort, DataContext context) :base (httpContextAccessort)
        {
            _context = context;
        }

        // GET: api/NghiPhep
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NghiPhepDetail>>> GetNghiPhep()
        {
            var model = await _context.NghiPhep.ToListAsync();
            var result = model.Select(x => new NghiPhepDetail()
            {
                Id = x.Id,
                LoaiNghi = x.LoaiNghi,
                LyDo = x.LyDo,
                NguoiPheDuyet = x.NguoiPheDuyet != null ? x.NguoiPheDuyet.HoVaTen : "",
                TaoChoNgay = x.TaoChoNgay,
                TenNhanVien = x.NhanVien != null ? x.NhanVien.HoVaTen : "",
                ThoiGianTao = x.ThoiGianTao,
                TrangThai = x.TrangThai,
            }).ToList();
            return result;
        }

        // GET: api/NghiPhep/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NghiPhep>> GetNghiPhep(int id)
        {
            var nghiPhep = await _context.NghiPhep.FindAsync(id);

            if (nghiPhep == null)
            {
                return NotFound();
            }

            return nghiPhep;
        }

        // PUT: api/NghiPhep/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNghiPhep(int id, NghiPhep nghiPhep)
        {
            if (id != nghiPhep.Id)
            {
                return BadRequest();
            }

            _context.Entry(nghiPhep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NghiPhepExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut("{id}/update-status")]
        public async Task<IActionResult> UpdateStatus(int id, int status = 1)
        {
            var nghiPhep = await _context.NghiPhep.FindAsync(id);
            if (nghiPhep == null)
                return BadRequest();
            nghiPhep.TrangThai = (TrangThaiNghiEnum)status;
            _context.Entry(nghiPhep).State = EntityState.Detached;
            _context.Entry(nghiPhep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NghiPhepExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NghiPhep
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(PRIVILGE.USER, PRIVILGE.OTHER)]
        public async Task<ActionResult<NghiPhep>> PostNghiPhep([FromBody]NghiPhep nghiPhep)
        {
            var userIdentiy = (User)HttpContext.Items["User"];
            //var userId = int.Parse(userIdentiy.Claims.First(x => x.Type == "Id").Value);

            //var user = User.Claims.First(x=>x.Type == "id")?.Value;
            //string userId = User.FindFirst(ClaimTypes.Sid)?.Value;
            
            if(UserIdentity != null)
            {
                nghiPhep.NhanVienId = UserIdentity.Id;
            }
          
            nghiPhep.ThoiGianTao = DateTime.Now;
            nghiPhep.TrangThai = TrangThaiNghiEnum.ChoDuyet;
            _context.NghiPhep.Add(nghiPhep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNghiPhep", new { id = nghiPhep.Id }, nghiPhep);
        }

        // DELETE: api/NghiPhep/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNghiPhep(int id)
        {
            var nghiPhep = await _context.NghiPhep.FindAsync(id);
            if (nghiPhep == null)
            {
                return NotFound();
            }

            _context.NghiPhep.Remove(nghiPhep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NghiPhepExists(int id)
        {
            return _context.NghiPhep.Any(e => e.Id == id);
        }
    }
}
