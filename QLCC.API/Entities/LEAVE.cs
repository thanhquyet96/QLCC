using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static QLCC.ViewModels.Constants;

namespace QLCC.Entities
{
    public class LEAVE
    {
        public int ID { get; set; }
        public int USER_ID { get; set; }
        public int APPROVE_USER_ID { get; set; }
        public string REASON { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public DateTime TaoChoNgay { get; set; }
        public LoaiNghiEnum LoaiNghi { get; set; }
        public HinhThucNghiEnum HinhThucNghi { get; set; }
        public TrangThaiNghiEnum TrangThai { get; set; }
        [JsonIgnore]
        [ForeignKey("NhanVienId")]
        public virtual USER USER { get; set; }
        [ForeignKey("NguoiPheDuyetId")]
        [JsonIgnore]
        [InverseProperty("NghiPheps")]
        public virtual USER APPROVE_USER { get; set; }
    }
}
