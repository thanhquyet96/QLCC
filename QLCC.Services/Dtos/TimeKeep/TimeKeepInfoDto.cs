using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Services.Dtos.TimeKeep
{
	public class TimeKeepInfoDto
	{
        public int Id { get; set; }
        //public string Ten { get; set; }
        public int? UserId { get; set; }
        public int? DateTimeKeepId { get; set; }
        public DateTime DateTimeKeepDate { get; set; }
        public string DateTimeKeepName { get; set; }
        public DateTime DateTimeKeepTimeCheckIn { get; set; }
    }
}

