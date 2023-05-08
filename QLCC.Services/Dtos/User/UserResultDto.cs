using System;
using QLCC.Services.Dtos.UserRole;

namespace QLCC.Services.Dtos.User
{
	public class UserResultDto
	{
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public List<string>? Roles { get; set; }
        public List<UserRoleInfoDto> UserRoles { get; set; }
        //public UserResultDto(User user, string token)
        //{
        //    Id = user.Id;
        //    FullName = user.FullName;
        //    Username = user.TaiKhoan;
        //    Token = token;
        //    Roles = user.NhanVien_Quyens?.Select(x => x.Quyen.TenQuyen).ToList();
        //}
    }
}

