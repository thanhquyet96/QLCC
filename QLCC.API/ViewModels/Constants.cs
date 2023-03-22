using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace QLCC.ViewModels
{
    public static class Constants
    {
        public enum LoaiNghiEnum
        {
            [Display(Name = "Nghỉ không lương")]
            NghiKhongLuong = 1,
            [Display(Name = "Nghỉ phép")]
            NghiPhep = 2,
        }
        public enum TrangThaiNghiEnum
        {
            [Display(Name = "Chờ duyệt")]
            ChoDuyet = 1,
            [Display(Name = "Đã duyệt")]
            DaDuyet = 2,
            [Display(Name = "Từ chối")]
            TuChoi = 3,
        }
        
    }
    public static class PRIVILGE
    {
       public const string ADMIN = "ADMIN";
        public const string USER = "USER";
        public const string OTHER = "OTHER";
    }
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
