using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace QLCC.ViewModels
{
    public static class Constants
    {
        public enum HinhThucNghiEnum
        {
            [Display(Name = "Nghỉ không lương")]
            [Description("Nghỉ không lương")]
            NghiKhongLuong = 1,
            [Display(Name = "Nghỉ phép")]
            [Description("Nghỉ phép")]
            NghiPhep = 2,
        }
        public enum LoaiNghiEnum
        {
            // =1 nếu đi làm full
            [Description("Nghỉ cả ngày")]
            NghiCaNgay = 2,
            [Description("Nghỉ buổi sáng")]
            NghiSang = 3,
            [Description("Nghỉ buổi chiều")]
            NghiChieu = 4,
        }
        public enum TrangThaiNghiEnum
        {
            [Display(Name = "Chờ duyệt")]
            [Description("Chờ duyệt")]
            ChoDuyet = 1,
            [Display(Name = "Đã duyệt")]
            [Description("Đã duyệt")]
            DaDuyet = 2,
            [Display(Name = "Từ chối")]
            [Description("Từ chối")]
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
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
        public static string GetDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }

}
