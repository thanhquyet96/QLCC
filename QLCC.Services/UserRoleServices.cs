using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using QLCC.Data;
using QLCC.Data.Entities;
using QLCC.Services.Dtos.UserRole;
using Repository;
using Service;
using UnitOfWork;

namespace QLCC.Services
{
    public class UserRoleServices : QLCCBaseServices<USER_ROLE>
    {
        private readonly IRepository<QLCCContext, USER_ROLE> _repository;
        public UserRoleServices(IRepository<QLCCContext, USER_ROLE> repository, IMapper mapper, ILogger<QLCCBaseServices<USER_ROLE>> logger, IUnitOfWork<QLCCContext> unitOfWork) : base(repository, mapper, logger, unitOfWork)
        {
            _repository = repository;
        }
        public async Task Post(int userId, List<int> quyens)
        {
            try
            {
                var quyenNhanVien = await base.Filter<UserRoleInfoDto>(x => x.UserId == userId).Select(x => x.RoleId).ToListAsync();
                foreach (var item in quyenNhanVien)
                {

                    await _repository.FromSql($"DELETE USER_ROLE WHERE ROLE_ID = {item} AND USER_ID = {userId};");
                    await _unitOfWork.Save();
                }
                foreach (var item in quyens)
                {
                    //await base.Add<UserRoleCreateDto>(new UserRoleCreateDto { UserId = userId, RoleId = item });
                    await _repository.FromSql($"INSERT INTO USER_ROLE(USER_ID, ROLE_ID) VALUES({userId},{item});");
                }
                //await _unitOfWork.Save();
            }
            catch (Exception e)
            {

            }
        }
    }
}

