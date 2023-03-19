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
    public class NghiPhepController : ControllerBase
    {
        private readonly DataContext _context;

        public NghiPhepController(DataContext context)
        {
            _context = context;
        }

        // GET: api/NghiPhep
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NghiPhep>>> GetNghiPhep()
        {
            return await _context.NghiPhep.ToListAsync();
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

        // POST: api/NghiPhep
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NghiPhep>> PostNghiPhep(NghiPhep nghiPhep)
        {
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
