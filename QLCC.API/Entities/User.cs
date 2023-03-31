using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QLCC.Entities
{
    [Table("NhanVien")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string TaiKhoan { get; set; }
        [JsonIgnore]
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }

        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime? SinhNhat { get; set; }
        public double? HeSoLuong { get; set; }
        public int? NgayNghiPhep { get; set; }
        public int? SoNgayDaNghi { get; set; }
        public decimal? LuongCoBan { get; set; }
        public virtual ICollection<NhanVien_Quyen> NhanVien_Quyens { get; set; }
        [InverseProperty("NguoiPheDuyet")]
        public virtual ICollection<NghiPhep> NghiPheps { get; set; }
        [InverseProperty("NhanVien")]
        public virtual ICollection<ChamCong> ChamCongs { get; set; }
    }
}
