using QLCC.Data.Entities;
using QLCC.Data;
using QLCC.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLCC.Services.Dtos.User;
using QLCC.Services.Dtos.DateTimeKeep;
using QLCC.Services.Dtos.HistoryTimeKeep;
using QLCC.Services.Dtos.Leave;
using QLCC.Services.Dtos.Role;
using QLCC.Services.Dtos.TimeKeep;
using QLCC.Services.Dtos.UserRole;

namespace QLCC.Services.Profiles
{
    public class MasterDtoToEntity : DtoToEntity
    {
        public MasterDtoToEntity()
        {
            CreateMap<DateTimeKeepCreateDto, DATE_TIME_KEEP>();
            CreateMap<DateTimeKeepUpdateDto, DATE_TIME_KEEP>();

            CreateMap<HistoryTimeKeepCreateDto, HISTORY_TIME_KEEP>();

            CreateMap<LeaveCreateDto, LEAVE>();
            CreateMap<LeaveUpdateDto, LEAVE>();
            CreateMap<LeaveUpdateStatusDto, LEAVE>();

            CreateMap<RoleCreateDto, ROLE>();
            CreateMap<RoleUpdateDto, ROLE>();


            CreateMap<TimeKeepCreateDto, TIME_KEEP>();

            CreateMap<UserCreateDto, USER>();
            CreateMap<UserUpdateDto, USER>();


            CreateMap<UserRoleCreateDto, ROLE>();

            CreateMap<UserRegisterDto, USER>();

            CreateMap<UserRoleCreateDto, USER_ROLE>();
        }
    }

    public class MasterEntityToDto : EntityToDto
    {
        public MasterEntityToDto()
        {
            CreateMap<DATE_TIME_KEEP, DateTimeKeepGridDto>();
            CreateMap<DATE_TIME_KEEP, DateTimeKeepInfoDto>();

            CreateMap<HISTORY_TIME_KEEP, HistoryTimeKeepGridDto>();
            CreateMap<HISTORY_TIME_KEEP, HistoryTimeKeepInfoDto>();


            CreateMap<LEAVE, LeaveDetailDto>();
            CreateMap<LEAVE, LeaveGridDto>();
            CreateMap<LEAVE, LeaveInfoDto>();

            CreateMap<ROLE, RoleGridDto>();
            CreateMap<ROLE, RoleInfoDto>();

            CreateMap<TIME_KEEP, TimeKeepGridDto>();
            CreateMap<TIME_KEEP, TimeKeepInfoDto>();


            CreateMap<USER_ROLE, UserRoleInfoDto>();
            CreateMap<USER_ROLE, UserRoleGridDto>();


            CreateMap<USER, UserGridDto>();
            CreateMap<USER, UserResultDto>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.USER_ROLES != null ? src.USER_ROLES.Select(x => x.ROLE != null ? x.ROLE.NAME : "") : null));
            CreateMap<USER, UserInfoDto>();
        }
    }
}
