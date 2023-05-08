using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Data.Entities
{
    [Table("DATE_TIME_KEEP")]
    public class DATE_TIME_KEEP
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public DateTime DATE { get; set; }
        //public string NhanVienId { get; set; }
        public DateTime TIME_CHECK_IN { get; set; }
        public DateTime TIME_CHECK_OUT { get; set; }
        [InverseProperty("DATE_TIME_KEEP")]
        public virtual ICollection<TIME_KEEP> TIME_KEEPS { get; set;}
    }
}
