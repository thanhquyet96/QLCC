using System;
namespace QLCC.Services.Dtos.TimeKeep
{
	public class TimeKeepCreateDto
	{
        //NhanVienId = UserIdentity.Id,
        //            NgayChamCongId = ngayChamCong.Id,

		public int UserId { get; set; }
		public int DateTimeKeepId { get; set; }
	}
}

