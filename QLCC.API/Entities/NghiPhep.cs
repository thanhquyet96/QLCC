using System.ComponentModel.DataAnnotations.Schema;
using static QLCC.ViewModels.Constants;

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
        public LoaiNghiEnum LoaiNghi { get; set; }
        public TrangThaiNghiEnum TrangThai { get; set; }
        [ForeignKey("NhanVienId")]
        public virtual User? NhanVien { get; set; }
        [ForeignKey("NguoiPheDuyetId")]
        public virtual User? NguoiPheDuyet { get; set; }
    }
}
