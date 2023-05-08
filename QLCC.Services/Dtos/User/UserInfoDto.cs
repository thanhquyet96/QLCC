using System;
using System.Text.Json.Serialization;
using QLCC.Services.Dtos.Leave;
using QLCC.Services.Dtos.UserRole;

namespace QLCC.Services.Dtos.User
{
	public class UserInfoDto
	{
        public int Id { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string FullName { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// Lương cơ bản
        /// </summary>
        public double? CoefficientsSalary { get; set; }
        /// <summary>
        /// Ngày nghỉ phép
        /// </summary>
        public int? VacationDay { get; set; }
        /// <summary>
        /// Số ngày đã nghỉ
        /// </summary>
        public int? NumberOfDays { get; set; }
        /// <summary>
        /// Lương
        /// </summary>
        public decimal? Salary { get; set; }
        public List<LeaveInfoDto> LeaveInfoDto { get; set; }
        public List<UserRoleInfoDto> UserRoles { get; set; }

    }
}

