using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Entities
{
    [Table("ChamCong")]
    [Description("Chấm công")]
    public class TIME_KEEP
    {
        public int ID { get; set; }
        //public string Ten { get; set; }
        public int? USER_ID { get; set; }
        public int? DATE_TIME_KEEP_ID { get; set; }
        [ForeignKey("DATE_TIME_KEEP_ID")]
        [InverseProperty("TIMEKEEPS")]
        public virtual DATE_TIME_KEEP DATE_TIME_KEEP { get; set; }
        [ForeignKey("USER_ID")]
        [InverseProperty("TIMEKEEPS")]
        public virtual USER USER { get; set; }
    }
}
