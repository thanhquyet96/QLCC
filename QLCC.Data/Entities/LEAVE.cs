using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static QLCC.Data.Constants;

namespace QLCC.Data.Entities
{
    [Table("LEAVE")]
    public class LEAVE
    {
        [Key]
        public int ID { get; set; }
        public int USER_ID { get; set; }
        public int APPROVE_USER_ID { get; set; }
        public string REASON { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public DateTime CREATED_FOR_DAY { get; set; }
        public LeaveTypeEnum LEAVE_TYPE { get; set; }
        public LeaveFormEnum LEAVE_FORM { get; set; }
        public LeaveStatusEnum LEAVE_STATUS { get; set; }
        [JsonIgnore]
        [ForeignKey("USER_ID")]
        public virtual USER USER { get; set; }
        [ForeignKey("APPROVE_USER_ID")]
        [JsonIgnore]
        [InverseProperty("LEAVES")]
        public virtual USER APPROVE_USER { get; set; }
    }
}
