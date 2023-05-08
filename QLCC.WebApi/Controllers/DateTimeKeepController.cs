using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCC.Services;
using QLCC.Services.Dtos.DateTimeKeep;
using QLCC.WebApi.Helpers;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DateTimeKeepController : ControllerBase
    {
        private readonly DateTimeKeepServices _dateTimeKeepServices;

        public DateTimeKeepController(DateTimeKeepServices dateTimeKeepServices)
        {
            _dateTimeKeepServices = dateTimeKeepServices;
        }

        // GET: api/DateTimeKeep
        [HttpGet]
        public async Task<ActionResult> GetDateTimeKeep([FromQuery]DateTimeKeepGridPagingDto pagingDto)
        {
            return Ok(await _dateTimeKeepServices.GetDateTimeKeeps(pagingDto));
        }

        // GET: api/DateTimeKeep/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DateTimeKeepInfoDto>> GetDateTimeKeep(int id)
        {
            var dateTimeKeep = await _dateTimeKeepServices.GetDateTimeKeep(id);
            return Ok(dateTimeKeep);
        }

        // PUT: api/DateTimeKeep/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDateTimeKeep(int id, DateTimeKeepUpdateDto dateTimeKeep)
        {
            await _dateTimeKeepServices.Update(id, dateTimeKeep);
            return Ok();
        }

        // POST: api/DateTimeKeep
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DateTimeKeepCreateDto>> PostDateTimeKeep(DateTimeKeepCreateDto dateTimeKeep)
        {
            await _dateTimeKeepServices.Add(dateTimeKeep);
            return Ok();
        }

        // DELETE: api/DateTimeKeep/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDateTimeKeep(int id)
        {
            await _dateTimeKeepServices.Delete(id);
            return Ok();
        }
    }
}
