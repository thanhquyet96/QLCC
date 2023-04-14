using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCC.Entities;
using QLCC.Helpers;
using QLCC.Models;
using QLCC.ViewModels;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(PRIVILGE.USER, PRIVILGE.OTHER)]
    public class NhanVienController : BaseController
    {
        private readonly DataContext _context;

        public NhanVienController(IHttpContextAccessor httpContextAccessort, DataContext context) : base(httpContextAccessort)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(string keyword)
        {
            var users = await _context.Users.ToListAsync();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                
                users = users.Where(x=>x.HoVaTen.Contains(keyword) || x.TaiKhoan.Contains(keyword)).ToList();
            }

            if (UserIdentity.OnlyUser)
            {
                users = users.Where(x => x.Id == UserIdentity.Id).ToList();
            }
            return users;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserUpdate user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            var userOld = await _context.Users.FindAsync(id);
            if(userOld != null){
                userOld.DiaChi = user.DiaChi;
                userOld.SoDienThoai = user.SoDienThoai;
                userOld.HoVaTen = user.HoVaTen;
                userOld.HeSoLuong = user.HeSoLuong;
                userOld.SoNgayDaNghi = user.SoNgayDaNghi;
                userOld.SinhNhat = user.SinhNhat;
                userOld.NgayNghiPhep = user.NgayNghiPhep;
            }
            _context.Entry(userOld).State = EntityState.Detached;
            _context.Entry(userOld).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
