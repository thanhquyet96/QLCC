using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCC.Entities;
using QLCC.Helpers;
using QLCC.Models;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NgayChamCongController : ControllerBase
    {
        private readonly DataContext _context;

        public NgayChamCongController(DataContext context)
        {
            _context = context;
        }

        // GET: api/NgayChamCong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DateTimeKeep>>> GetNgayChamCong()
        {
            return await _context.NgayChamCong.ToListAsync();
        }

        // GET: api/NgayChamCong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DateTimeKeep>> GetNgayChamCong(int id)
        {
            var ngayChamCong = await _context.NgayChamCong.FindAsync(id);

            if (ngayChamCong == null)
            {
                return NotFound();
            }

            return ngayChamCong;
        }

        // PUT: api/NgayChamCong/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNgayChamCong(int id, DateTimeKeep ngayChamCong)
        {
            if (id != ngayChamCong.Id)
            {
                return BadRequest();
            }

            _context.Entry(ngayChamCong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NgayChamCongExists(id))
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

        // POST: api/NgayChamCong
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DateTimeKeep>> PostNgayChamCong(DateTimeKeep ngayChamCong)
        {
            _context.NgayChamCong.Add(ngayChamCong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNgayChamCong", new { id = ngayChamCong.Id }, ngayChamCong);
        }

        // DELETE: api/NgayChamCong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNgayChamCong(int id)
        {
            var ngayChamCong = await _context.NgayChamCong.FindAsync(id);
            if (ngayChamCong == null)
            {
                return NotFound();
            }

            _context.NgayChamCong.Remove(ngayChamCong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NgayChamCongExists(int id)
        {
            return _context.NgayChamCong.Any(e => e.Id == id);
        }
    }
}
