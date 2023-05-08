using System;
namespace QLCC.Services.Dtos.HistoryTimeKeep
{
	public class HistoryTimeKeepCreateDto
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TimeTimeKeep { get; set; }
        public DateTime DateTimeKeep { get; set; }
    }
}

