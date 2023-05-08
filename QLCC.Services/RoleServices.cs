using System;
using AutoMapper;
using Common;
using Microsoft.Extensions.Logging;
using QLCC.Data;
using QLCC.Data.Entities;
using QLCC.Services.Dtos.Role;
using Repository;
using UnitOfWork;

namespace QLCC.Services
{
    public class RoleServices : QLCCBaseServices<ROLE>
    {
        public RoleServices(IRepository<QLCCContext, ROLE> repository, IMapper mapper, ILogger<QLCCBaseServices<ROLE>> logger, IUnitOfWork<QLCCContext> unitOfWork) : base(repository, mapper, logger, unitOfWork)
        {
        }

        public async Task<PagingResult<RoleGridDto>> GetRoles(RoleGridPagingDto pagingDto)
        {
            return await base.FilterPage<RoleGridDto>(pagingDto);
        }
        public async Task<RoleInfoDto>GetRole(int id)
        {
            return await base.Find<RoleInfoDto>(id);
        }
        public async Task Add(RoleCreateDto role)
        {
            await base.Add<RoleCreateDto>(role);
            await _unitOfWork.Save();
        }
        public async Task Update(int id,RoleUpdateDto role)
        {
            await base.Update<RoleUpdateDto>(id, role);
            await _unitOfWork.Save();
        }
        public async Task Delete(int id)
        {
            await base.Delete(id);
            await _unitOfWork.Save();
        }
    }
}

