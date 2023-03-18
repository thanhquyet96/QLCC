using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCC.Entities;
using QLCC.Models;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVien_QuyenController : ControllerBase
    {
        private readonly DataContext _context;

        public NhanVien_QuyenController(DataContext context)
        {
            _context = context;
        }

        // GET: api/NhanVien_Quyen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVien_Quyen>>> GetNhanVien_Quyen()
        {
            return await _context.NhanVien_Quyen.ToListAsync();
        }

        // GET: api/NhanVien_Quyen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVien_Quyen>> GetNhanVien_Quyen(int? id)
        {
            var nhanVien_Quyen = await _context.NhanVien_Quyen.FindAsync(id);

            if (nhanVien_Quyen == null)
            {
                return NotFound();
            }

            return nhanVien_Quyen;
        }

        // PUT: api/NhanVien_Quyen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanVien_Quyen(int? id, NhanVien_Quyen nhanVien_Quyen)
        {
            if (id != nhanVien_Quyen.QuyenId)
            {
                return BadRequest();
            }

            _context.Entry(nhanVien_Quyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVien_QuyenExists(id))
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

        // POST: api/NhanVien_Quyen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NhanVien_Quyen>> PostNhanVien_Quyen(NhanVien_Quyen nhanVien_Quyen)
        {
            _context.NhanVien_Quyen.Add(nhanVien_Quyen);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NhanVien_QuyenExists(nhanVien_Quyen.QuyenId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNhanVien_Quyen", new { id = nhanVien_Quyen.QuyenId }, nhanVien_Quyen);
        }

        // DELETE: api/NhanVien_Quyen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien_Quyen(int? id)
        {
            var nhanVien_Quyen = await _context.NhanVien_Quyen.FindAsync(id);
            if (nhanVien_Quyen == null)
            {
                return NotFound();
            }

            _context.NhanVien_Quyen.Remove(nhanVien_Quyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhanVien_QuyenExists(int? id)
        {
            return _context.NhanVien_Quyen.Any(e => e.QuyenId == id);
        }
    }
}
