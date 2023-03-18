using System;

namespace QLCC.Entities
{
    public class NghiPhep
    {
        public int Id { get; set; }
        public int NhanVienId { get; set; }
        public int NguoiPheDuyetId { get; set; }
        public string LyDo { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime TaoChoNgay { get; set; }
        public string LoaiNghi { get; set; }
        public string TrangThai { get; set; }
    }
}
