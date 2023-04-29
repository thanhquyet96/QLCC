using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Data.Entities
{
    [Table("TIME_KEEP")]
    [Description("Chấm công")]
    public class TIME_KEEP
    {
        public int ID { get; set; }
        //public string Ten { get; set; }
        public int? USER_ID { get; set; }
        public int? DATE_TIME_KEEP_ID { get; set; }
        [ForeignKey("DATE_TIME_KEEP_ID")]
        [InverseProperty("TIME_KEEPS")]
        public virtual DATE_TIME_KEEP DATE_TIME_KEEP { get; set; }
        [ForeignKey("USER_ID")]
        [InverseProperty("TIME_KEEPS")]
        public virtual USER USER { get; set; }
    }
}
