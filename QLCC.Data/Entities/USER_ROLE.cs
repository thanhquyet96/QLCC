using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Data.Entities
{
    public class USER_ROLE
    {
        [Key]
        [Column(Order = 1)]
        public int? USER_ID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int? ROLE_ID { get; set; }
        [ForeignKey("ROLE_ID")]
        public virtual ROLE ROLE { get; set; }
        [ForeignKey("USER_ID")]
        public virtual USER USER { get; set; }
    }
}
