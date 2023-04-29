using System;
using AutoMapper;
using Common;
using QLCC.Data;
using QLCC.Data.Entities;
using QLCC.Services.Dtos.User;
using Repository;
using Service;

namespace QLCC.Services
{
    public class UserServices : QLCCBaseServices<USER>
    {
        public UserServices(IRepository<QLCCContext, USER> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public async Task<PagingResult<UserGridDto>> GetUsers(UserGridPagingDto pagingModel)
        {
            return await base.FilterPage<UserGridDto>(pagingModel);
        }
    }


}

