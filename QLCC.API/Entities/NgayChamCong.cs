using System;

namespace QLCC.Entities
{
    public class NgayChamCong
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string NhanVienId { get; set; }
        public DateTime ThoiGianChamCong { get; set; }
        public DateTime ThoiGianRaVe { get; set; }

    }
}
