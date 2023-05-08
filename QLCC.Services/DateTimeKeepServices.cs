using System;
using AutoMapper;
using Common;
using Microsoft.Extensions.Logging;
using QLCC.Data;
using QLCC.Data.Entities;
using QLCC.Services.Dtos.DateTimeKeep;
using Repository;
using UnitOfWork;

namespace QLCC.Services
{
    public class DateTimeKeepServices : QLCCBaseServices<DATE_TIME_KEEP>
    {
        public DateTimeKeepServices(IRepository<QLCCContext, DATE_TIME_KEEP> repository, IMapper mapper, ILogger<QLCCBaseServices<DATE_TIME_KEEP>> logger, IUnitOfWork<QLCCContext> unitOfWork) : base(repository, mapper, logger, unitOfWork)
        {
        }
        public async Task<PagingResult<DateTimeKeepGridDto>> GetDateTimeKeeps(DateTimeKeepGridPagingDto pagingDto)
        {
            return await base.FilterPage<DateTimeKeepGridDto>(pagingDto);
        }

        public async Task<DateTimeKeepInfoDto> GetDateTimeKeep(int id)
        {
            return await base.Find<DateTimeKeepInfoDto>(id);
        }
    }
}

