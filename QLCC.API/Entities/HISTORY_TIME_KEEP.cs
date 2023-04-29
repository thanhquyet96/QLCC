using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Entities
{
    public class HISTORY_TIME_KEEP
    {
        public int ID { get; set; }
        public int USER_ID { get; set; }
        public decimal TIME_TIME_KEEP { get; set; }
        public DateTime DATE_TIME_KEEP { get; set; }
        [ForeignKey("USER_ID")]
        public virtual USER USER { get; set; } 
    }
}
