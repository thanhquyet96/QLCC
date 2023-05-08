using System;
namespace QLCC.Services.Dtos.DateTimeKeep
{
	public class DateTimeKeepCreateDto
	{
        //ThoiGianChamCong = dateNow,
        //            ThoiGianRaVe = dateNow,
        //            Ten = dateNow.ToString("dd-MM-yyyy"),
        //            Date = dateNow,
        public int Id { get; set; }
        public string Name
        {
            get
            {
                return Date.ToString("dd-MM-yyyy");
            }
        }
        public DateTime Date { get; set; }
        //public string NhanVienId { get; set; }
        public DateTime TimeCheckIn { get; set; }
        public DateTime TimeCheckOut { get; set; }
    }
}

