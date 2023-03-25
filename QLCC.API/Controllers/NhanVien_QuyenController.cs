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
        [HttpPost("{userId}")]
        public async Task<IActionResult> Post(int userId, List<int> quyens)
        {
            try
            {
                var quyenNhanVien = _context.NhanVien_Quyen.Where(x => x.NhanVienId == userId);
                _context.NhanVien_Quyen.RemoveRange(quyenNhanVien);
                foreach (var item in quyens)
                {
                    await _context.NhanVien_Quyen.AddAsync(new NhanVien_Quyen { NhanVienId = userId, QuyenId = item});
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
        
    }
}
