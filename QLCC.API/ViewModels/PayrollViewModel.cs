namespace QLCC.ViewModels
{
    public class PayrollViewModel
    {
        public string HoVaTen { get; set; } 
        public double HeSoLuong { get; set; } 
        public double SoNgayNghiHuongLuong { get; set; } 
        public double SoNgayNghiKhongHuongLuong { get; set; } 
        public decimal TienLuong { get; set; } 
        public IDictionary<string, object> ValuePairs { get; set; }
    }
}
