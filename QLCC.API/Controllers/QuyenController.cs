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
    public class QuyenController : ControllerBase
    {
        private readonly DataContext _context;

        public QuyenController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Quyen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quyen>>> GetQuyen(string keyword)
        {
            var model = await _context.Quyen.ToListAsync();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                model = model.Where(x => x.TenQuyen.ToLower().Contains(keyword.ToLower())).ToList();
            }
            return model;
        }

        // GET: api/Quyen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quyen>> GetQuyen(int id)
        {
            var quyen = await _context.Quyen.FindAsync(id);

            if (quyen == null)
            {
                return NotFound();
            }

            return quyen;
        }

        // PUT: api/Quyen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuyen(int id, Quyen quyen)
        {
            if (id != quyen.Id)
            {
                return BadRequest();
            }

            _context.Entry(quyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuyenExists(id))
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

        // POST: api/Quyen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quyen>> PostQuyen(Quyen quyen)
        {
            _context.Quyen.Add(quyen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuyen", new { id = quyen.Id }, quyen);
        }

        // DELETE: api/Quyen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuyen(int id)
        {
            var quyen = await _context.Quyen.FindAsync(id);
            if (quyen == null)
            {
                return NotFound();
            }

            _context.Quyen.Remove(quyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuyenExists(int id)
        {
            return _context.Quyen.Any(e => e.Id == id);
        }
    }
}
