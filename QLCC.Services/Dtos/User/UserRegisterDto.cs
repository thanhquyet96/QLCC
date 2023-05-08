using System;
using System.ComponentModel.DataAnnotations;

namespace QLCC.Services.Dtos.User
{
	public class UserRegisterDto
	{
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RePassword { get; set; }
    }
}

