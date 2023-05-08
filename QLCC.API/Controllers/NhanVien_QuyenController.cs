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
    public class NhanVien_QuyenController : ControllerBase
    {
        private readonly DataContext _context;

        public NhanVien_QuyenController(DataContext context)
        {
            _context = context;
        }

        // GET: api/NhanVien_Quyen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<USER_ROLE>>> GetNhanVien_Quyen()
        {
            return await _context.NhanVien_Quyen.ToListAsync();
        }
        [HttpPost("{userId}")]
        public async Task<IActionResult> Post(int userId, List<int> quyens)
        {
            try
            {
                var quyenNhanVien = _context.NhanVien_Quyen.Where(x => x.USER_ID == userId);
                _context.NhanVien_Quyen.RemoveRange(quyenNhanVien);
                foreach (var item in quyens)
                {
                    await _context.NhanVien_Quyen.AddAsync(new USER_ROLE { USER_ID = userId, ROLE_ID = item});
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
