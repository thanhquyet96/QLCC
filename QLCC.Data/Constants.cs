using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace QLCC.Data
{
    public static class Constants
    {
        /// <summary>
        /// Hình thức nghỉ
        /// </summary>
        public enum LeaveFormEnum
        {
            /// <summary>
            /// Nghỉ Không lương
            /// </summary>
            [Display(Name = "Nghỉ không lương")]
            [Description("Nghỉ không lương")]
            UnpaidLeave = 1,
            /// <summary>
            /// Nghỉ phép
            /// </summary>
            [Display(Name = "Nghỉ phép")]
            [Description("Nghỉ phép")]
            OnLeave = 2,
        }
        /// <summary>
        /// Loại nghỉ
        /// </summary>
        public enum LeaveTypeEnum
        {
            // =1 nếu đi làm full
            /// <summary>
            /// ĐI làm full
            /// </summary>
            FullDay = 1,
            /// <summary>
            /// Nghỉ cả ngày
            /// </summary>
            [Description("Nghỉ cả ngày")]
            OffFullDay = 2,
            /// <summary>
            /// Nghỉ sáng
            /// </summary>
            [Description("Nghỉ buổi sáng")]
            OffMorning = 3,
            /// <summary>
            /// Nghỉ chiều
            /// </summary>
            [Description("Nghỉ buổi chiều")]
            OffAfternoon = 4,
            /// <summary>
            /// Không xác định
            /// </summary>
            [Description("Không xác định")]
            Orther = 5,
        }
        public enum LeaveStatusEnum
        {
            [Display(Name = "Chờ duyệt")]
            [Description("Chờ duyệt")]
            Pending = 1,
            [Display(Name = "Đã duyệt")]
            [Description("Đã duyệt")]
            Approved = 2,
            [Display(Name = "Từ chối")]
            [Description("Từ chối")]
            Reject = 3,
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
