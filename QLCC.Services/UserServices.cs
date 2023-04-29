using System;
using AutoMapper;
using QLCC.Data;
using QLCC.Data.Entities;
using Repository;
using Service;

namespace QLCC.Services
{
    public class UserServices : BaseServices<QLCCContext, USER>
    {
        public UserServices(IRepository<QLCCContext, USER> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

