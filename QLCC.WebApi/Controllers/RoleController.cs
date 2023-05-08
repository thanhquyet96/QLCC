using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCC.Services;
using QLCC.Services.Dtos.Role;
using QLCC.WebApi.Helpers;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly RoleServices _roleServices;

        public RoleController(RoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<ActionResult> GetRole([FromQuery]RoleGridPagingDto pagingDto)
        {
            var result = await _roleServices.FilterPage<RoleGridDto>(pagingDto);
            return Ok(result);
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleInfoDto>> GetRole(int id)
        {
            var role = await _roleServices.Find<RoleInfoDto>(id);

            return Ok(role);
        }

        // PUT: api/Role/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, RoleUpdateDto role)
        {
            await _roleServices.Update(id, role);
            return Ok();
        }

        // POST: api/Role
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostRole(RoleCreateDto role)
        {
            await _roleServices.Add(role);
            return Ok();
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleServices.Delete(id);
            return Ok();
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListRoles()
        {
            return Ok(_roleServices.Filter<RoleInfoDto>());
        }
    }
}
