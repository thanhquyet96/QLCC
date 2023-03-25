using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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
        public HinhThucNghiEnum HinhThucNghi { get; set; }
        public TrangThaiNghiEnum TrangThai { get; set; }
        [JsonIgnore]
        [ForeignKey("NhanVienId")]
        public virtual User NhanVien { get; set; }
        [ForeignKey("NguoiPheDuyetId")]
        [JsonIgnore]
        public virtual User NguoiPheDuyet { get; set; }
    }
}
