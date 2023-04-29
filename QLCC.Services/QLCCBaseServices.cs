using System;
using AutoMapper;
using QLCC.Data;
using Repository;
using Service;

namespace QLCC.Services
{
    public class QLCCBaseServices<TEnity> : BaseServices<QLCCContext, TEnity> where TEnity : class
    {
        public QLCCBaseServices(IRepository<QLCCContext, TEnity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

