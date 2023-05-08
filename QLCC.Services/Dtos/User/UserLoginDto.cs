using System;
using System.ComponentModel.DataAnnotations;

namespace QLCC.Services.Dtos.User
{
	public class UserLoginDto
	{
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

