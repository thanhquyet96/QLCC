using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCC.Services;
using QLCC.Services.Dtos.UserRole;
using QLCC.WebApi.Helpers;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserRoleController : ControllerBase
    {
        private readonly UserRoleServices _userRoleServices;

        public UserRoleController(UserRoleServices userRoleServices)
        {
            _userRoleServices = userRoleServices;
        }

        // GET: api/NhanVien_Quyen
        [HttpGet]
        public async Task<ActionResult<PagingResult<UserRoleGridDto>>> GetUserRoles([FromQuery] UserRoleGridPagingDto pagingDto)
        {
            return await _userRoleServices.FilterPage<UserRoleGridDto>(pagingDto);
        }
        [HttpPost("{userId}")]
        public async Task<IActionResult> Post(int userId, List<int> quyens)
        {
            await _userRoleServices.Post(userId, quyens);
            return Ok();
        }
        
    }
}
