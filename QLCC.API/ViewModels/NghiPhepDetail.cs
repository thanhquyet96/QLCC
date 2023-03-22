using Microsoft.OpenApi.Extensions;
using static QLCC.ViewModels.Constants;

namespace QLCC.Entities
{
    public class NghiPhepDetail
    {
        public string TenNhanVien { get; set; }
        public string NguoiPheDuyet { get; set; }
        public string LyDo { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime TaoChoNgay { get; set; }
        public LoaiNghiEnum? LoaiNghi { get; set; }
        public string TenLoaiNghi
        {
            get
            {
                if (LoaiNghi.HasValue)
                {
                    switch (LoaiNghi.Value)
                    {
                        case LoaiNghiEnum.NghiKhongLuong:
                            return LoaiNghiEnum.NghiKhongLuong.GetDisplayName();
                        case LoaiNghiEnum.NghiPhep:
                            return LoaiNghiEnum.NghiPhep.GetDisplayName();
                        default:
                            return "N/A";
                    }
                }
                return "N/A";
            }
        }
        public TrangThaiNghiEnum? TrangThai { get; set; }
        public string TenTrangThai
        {
            get
            {
                if (!TrangThai.HasValue) return "N/A";
                switch (TrangThai.Value)
                {
                    case TrangThaiNghiEnum.ChoDuyet:
                        return TrangThaiNghiEnum.ChoDuyet.GetDisplayName();
                    case TrangThaiNghiEnum.DaDuyet:
                        return TrangThaiNghiEnum.DaDuyet.GetDisplayName();
                    case TrangThaiNghiEnum.TuChoi:
                        return TrangThaiNghiEnum.TuChoi.GetDisplayName();
                    default:
                        return "N/A";
                }
            }
        }
    }
}
