using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using QLCC.Data;
using Repository;
using Service;
using UnitOfWork;

namespace QLCC.Services
{
    public class QLCCBaseServices<TEnity> : BaseServices<QLCCContext, TEnity> where TEnity : class
    {
        protected readonly ILogger<QLCCBaseServices<TEnity>> _logger;
        //private readonly AppSettings _appSettings;
        protected IUnitOfWork<QLCCContext> _unitOfWork;

        public QLCCBaseServices(IRepository<QLCCContext, TEnity> repository, IMapper mapper, ILogger<QLCCBaseServices<TEnity>> logger, IUnitOfWork<QLCCContext> unitOfWork) : base(repository, mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        //Task<bool> ContainAsync<TDto>(Expression<Func<TDto, bool>> exception);

    }
}

