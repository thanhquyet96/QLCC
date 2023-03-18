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
    public class ChamCongController : ControllerBase
    {
        private readonly DataContext _context;

        public ChamCongController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ChamCong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamCong>>> GetChamCong()
        {
            return await _context.ChamCong.ToListAsync();
        }

        // GET: api/ChamCong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChamCong>> GetChamCong(int id)
        {
            var chamCong = await _context.ChamCong.FindAsync(id);

            if (chamCong == null)
            {
                return NotFound();
            }

            return chamCong;
        }

        // PUT: api/ChamCong/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChamCong(int id, ChamCong chamCong)
        {
            if (id != chamCong.Id)
            {
                return BadRequest();
            }

            _context.Entry(chamCong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChamCongExists(id))
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

        // POST: api/ChamCong
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChamCong>> PostChamCong(ChamCong chamCong)
        {
            _context.ChamCong.Add(chamCong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChamCong", new { id = chamCong.Id }, chamCong);
        }

        // DELETE: api/ChamCong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChamCong(int id)
        {
            var chamCong = await _context.ChamCong.FindAsync(id);
            if (chamCong == null)
            {
                return NotFound();
            }

            _context.ChamCong.Remove(chamCong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChamCongExists(int id)
        {
            return _context.ChamCong.Any(e => e.Id == id);
        }
    }
}
