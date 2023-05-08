using System;
namespace QLCC.Services.Dtos.UserRole
{
	public class UserRoleGridDto
	{
		public int UserId { get; set; }
		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public string UserFullName { get; set; }
    }
}

