using System;
using AutoMapper;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QLCC.Data;
using QLCC.Data.Entities;
using QLCC.Services.Dtos.Leave;
using Repository;
using UnitOfWork;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static QLCC.Data.Constants;

namespace QLCC.Services
{
    public class LeaveServices : QLCCBaseServices<LEAVE>
    {
        public LeaveServices(IRepository<QLCCContext, LEAVE> repository, IMapper mapper, ILogger<QLCCBaseServices<LEAVE>> logger, IUnitOfWork<QLCCContext> unitOfWork) : base(repository, mapper, logger, unitOfWork)
        {
        }
        public async Task<PagingResult<LeaveGridDto>> GetLeaves(LeaveGridPagingDto pagingDto)
        {
            //var model = await _context.NghiPhep.Include(x => x.NguoiPheDuyet).Include(x => x.NhanVien).ToListAsync();
            var model = await base.FilterPage<LeaveGridDto>(pagingDto);
            //if (!string.IsNullOrWhiteSpace(keyword))
            //{
            //    model = model.Where(x => x.NhanVien.FullName.Contains(keyword)).ToList();
            //}
            //if (UserIdentity.OnlyUser)
            //{
            //    model = model.Where(x => x.NhanVienId == UserIdentity.Id).ToList();
            //}
            //var result = model.Data.Select(x => new LeaveDetailDto()
            //{
            //    Id = x.Id,
            //    LeaveType = x.LeaveType,
            //    Reason = x.Reason,
            //    ApproveUserFullName = x.ApproveUserFullName,
            //    CreatedForDay = x.CreatedForDay,
            //    UserFullName = x.UserFullName,
            //    CreatedDate = x.CreatedDate,
            //    LeaveStatus = x.LeaveStatus,
            //    LeaveForm = x.LeaveForm,
            //}).ToList();
            return model;
        }
        public async Task<LeaveDetailDto> GetLeave(int id)
        {
            return await base.Find<LeaveDetailDto>(id);
        }
        public async Task Add(LeaveCreateDto leave)
        {
            leave.CreatedDate = DateTime.Now;
            leave.LeaveStatus = LeaveStatusEnum.Pending;
            await base.Add<LeaveCreateDto>(leave);
            await _unitOfWork.Save();
        }
        public async Task Update(int id, LeaveUpdateDto leave)
        {
            await base.Update<LeaveUpdateDto>(id,leave);
            await _unitOfWork.Save();
        }
        public async Task UpdateStatus<LeaveUpdateStatusDto>(int id, LeaveUpdateStatusDto leave)
        {
            await base.Update<LeaveUpdateStatusDto>(id, leave);
            await _unitOfWork.Save();
        }
    }
}

