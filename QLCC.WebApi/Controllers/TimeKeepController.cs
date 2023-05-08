using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCC.Services;
using QLCC.WebApi.Helpers;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TimeKeepController : BaseController
    {
        private readonly TimeKeepServices _timeKeepServices;
        public TimeKeepController(IHttpContextAccessor httpContextAccessort, TimeKeepServices timeKeepServices) : base(httpContextAccessort)
        {
            _timeKeepServices = timeKeepServices;
        }

        [HttpPost]
        public async Task<ActionResult> PostChamCong([FromQuery] bool checkOut = false)
        {
            var userId = UserIdentity.Id;
            var result = _timeKeepServices.CheckInOut(userId);
            return Ok(result);
        }
        // Kiểm tra nhân viên đã CheckIn chưa
        [HttpGet("is-checkin")]
        public async Task<ActionResult> IsCheckIn()
        {
            var result = await _timeKeepServices.IsCheckIn(UserIdentity.Id);
            return Ok(result);
        }

        // Tính lương nhân viên
        [HttpPost("payroll")]
        public async Task<ActionResult> Payroll(int? year, int? month)
        {
            var result = await _timeKeepServices.PayRoll(year, month, UserIdentity.IsAdmin ? null : UserIdentity.Id);
            return Ok(result);
        }

    }
}
