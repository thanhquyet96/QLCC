using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCC.Entities;
using QLCC.Models;
using QLCC.ViewModels;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichSuChamCongController : ControllerBase
    {
        private readonly DataContext _context;

        public LichSuChamCongController(DataContext context)
        {
            _context = context;
        }

        // GET: api/LichSuChamCong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LichSuChamCongGrid>>> GetLichSuChamCong()
        {
            var result = await _context.LichSuChamCong.ToListAsync();
            var data = result.Select(x => new LichSuChamCongGrid()
            {
                NhanVienId = x.NhanVienId,
                NgayChamCong = x.NgayChamCong,
                ThoiGianChamCong = x.ThoiGianChamCong,
                LoaiNghi = x.NhanVien.NghiPheps.FirstOrDefault(y=>y.TaoChoNgay == x.NgayChamCong).LoaiNghi,
            });
            return data.ToList();
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

        // PUT: api/LichSuChamCong/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLichSuChamCong(int id, LichSuChamCong lichSuChamCong)
        {
            if (id != lichSuChamCong.Id)
            {
                return BadRequest();
            }

            _context.Entry(lichSuChamCong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichSuChamCongExists(id))
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

        // POST: api/LichSuChamCong
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LichSuChamCong>> PostLichSuChamCong(LichSuChamCong lichSuChamCong)
        {
            _context.LichSuChamCong.Add(lichSuChamCong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLichSuChamCong", new { id = lichSuChamCong.Id }, lichSuChamCong);
        }

        // DELETE: api/LichSuChamCong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLichSuChamCong(int id)
        {
            var lichSuChamCong = await _context.LichSuChamCong.FindAsync(id);
            if (lichSuChamCong == null)
            {
                return NotFound();
            }

            _context.LichSuChamCong.Remove(lichSuChamCong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LichSuChamCongExists(int id)
        {
            return _context.LichSuChamCong.Any(e => e.Id == id);
        }
    }
}
