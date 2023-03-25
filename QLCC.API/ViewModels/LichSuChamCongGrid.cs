using System;
using static QLCC.ViewModels.Constants;

namespace QLCC.ViewModels
{
    public class LichSuChamCongGrid
    {
        public int Id { get; set; }
        public int NhanVienId { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime ThoiGianChamCong { get; set; }
        public DateTime NgayChamCong { get; set; }
        public LoaiNghiEnum LoaiNghi { get; set; }
    }
}
