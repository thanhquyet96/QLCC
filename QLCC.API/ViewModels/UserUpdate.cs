namespace QLCC.Entities
{
    public class UserUpdate
    {
        public int Id { get; set; }
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime SinhNhat { get; set; }
        public double? HeSoLuong { get; set; }
        public int? NgayNghiPhep { get; set; }
        public int? SoNgayDaNghi { get; set; }
        public string MatKhauMoi { get; set; }
    }
}
