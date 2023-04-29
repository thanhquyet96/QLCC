using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCC.Services.Helpers
{
    public abstract class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            SourceMemberNamingConvention = PascalCaseNamingConvention.Instance;
            DestinationMemberNamingConvention = UpperUnderscoreNamingConvention.Instance;
        }
    }

    public abstract class EntityToDto : Profile
    {
        public EntityToDto()
        {
            SourceMemberNamingConvention = UpperUnderscoreNamingConvention.Instance;
            DestinationMemberNamingConvention = PascalCaseNamingConvention.Instance;
        }
    }
}
