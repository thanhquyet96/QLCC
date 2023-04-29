using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static QLCC.Data.Constants;

namespace QLCC.Data.Entities
{
    public class LEAVE
    {
        public int ID { get; set; }
        public int USER_ID { get; set; }
        public int APPROVE_USER_ID { get; set; }
        public string REASON { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public DateTime TaoChoNgay { get; set; }
        public LeaveTypeEnum LoaiNghi { get; set; }
        public LeaveFormEnum HinhThucNghi { get; set; }
        public LeaveStatusEnum TrangThai { get; set; }
        [JsonIgnore]
        [ForeignKey("USER_ID")]
        public virtual USER USER { get; set; }
        [ForeignKey("APPROVE_USER_ID")]
        [JsonIgnore]
        [InverseProperty("LEAVES")]
        public virtual USER APPROVE_USER { get; set; }
    }
}
