using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLCC.Services;
using QLCC.Services.Dtos.HistoryTimeKeep;
using QLCC.WebApi.Helpers;

namespace QLCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoryTimeKeepController : BaseController
    {
        private readonly HistoryTimeKeepServices _historyTimeKeepServices;

        public HistoryTimeKeepController(IHttpContextAccessor httpContextAccessort, HistoryTimeKeepServices historyTimeKeepServices) : base(httpContextAccessort)
        {
            _historyTimeKeepServices = historyTimeKeepServices;
        }

        // GET: api/LichSuChamCong
        [HttpGet]
        public async Task<IActionResult> GetHistoryTimeKeeps([FromQuery]HistoryTimeKeepGridPagingDto pagingParams)
        {
            var result = await _historyTimeKeepServices.GetHistoryTimeKeeps(pagingParams);
            return Ok(result);
        }

        // GET: api/LichSuChamCong/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistoryTimeKeep(int id)
        {
            var lichSuChamCong = await _historyTimeKeepServices.Find<HistoryTimeKeepInfoDto>(id);

            if (lichSuChamCong == null)
            {
                return NotFound();
            }

            return Ok(lichSuChamCong);
        }
    }
}
