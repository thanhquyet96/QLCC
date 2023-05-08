using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Data.Entities
{
    [Table("HISTORY_TIME_KEEP")]
    public class HISTORY_TIME_KEEP
    {
        [Key]
        public int ID { get; set; }
        public int USER_ID { get; set; }
        public decimal TIME_TIME_KEEP { get; set; }
        public DateTime DATE_TIME_KEEP { get; set; }
        [ForeignKey("USER_ID")]
        public virtual USER USER { get; set; } 
    }
}
