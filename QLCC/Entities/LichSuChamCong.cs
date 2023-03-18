using System;

namespace QLCC.Entities
{
    public class LichSuChamCong
    {
        public int Id { get; set; }
        public string NhanVienId { get; set; }
        public DateTime ThoiGianChamCong { get; set; }
        public DateTime NgayChamCong { get; set; }
    }
}
