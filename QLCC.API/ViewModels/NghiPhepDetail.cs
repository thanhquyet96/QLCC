using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json.Linq;
using QLCC.ViewModels;
using System;
using static QLCC.ViewModels.Constants;

namespace QLCC.Entities
{
    public class NghiPhepDetail
    {
        public int Id { get; set; }
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
                        case LoaiNghiEnum.NghiCaNgay:
                            return LoaiNghi.Value.GetDescription();
                            ;
                        case LoaiNghiEnum.NghiSang:
                            return LoaiNghi.Value.GetDescription();
                        case LoaiNghiEnum.NghiChieu:
                            return LoaiNghi.Value.GetDescription();
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
                        return TrangThaiNghiEnum.ChoDuyet.GetDescription();
                    case TrangThaiNghiEnum.DaDuyet:
                        return TrangThaiNghiEnum.DaDuyet.GetDescription();
                    case TrangThaiNghiEnum.TuChoi:
                        return TrangThaiNghiEnum.TuChoi.GetDescription();
                    default:
                        return "N/A";
                }
            }
        }

        public HinhThucNghiEnum? HinhThucNghi { get; set; }
        public string TenHinhThucNghi
        {
            get
            {
                if (HinhThucNghi.HasValue)
                {
                    switch (HinhThucNghi.Value)
                    {
                        case HinhThucNghiEnum.NghiKhongLuong:
                            return HinhThucNghi.Value.GetDescription();
                            ;
                        case HinhThucNghiEnum.NghiPhep:
                            return HinhThucNghi.Value.GetDescription();
                        default:
                            return "N/A";
                    }
                }
                return "N/A";
            }
        }
    }
}
