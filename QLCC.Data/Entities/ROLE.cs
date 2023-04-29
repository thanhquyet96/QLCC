using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Data.Entities
{
    [Table("ROLE")]
    public class ROLE
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public virtual ICollection<USER_ROLE> USER_ROLES { get; set;}
    }
}
