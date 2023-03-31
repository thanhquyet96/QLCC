using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Entities
{
    public class NgayChamCong
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public DateTime Date { get; set; }
        //public string NhanVienId { get; set; }
        public DateTime ThoiGianChamCong { get; set; }
        public DateTime ThoiGianRaVe { get; set; }
        [InverseProperty("NgayChamCong")]
        public virtual ICollection<ChamCong> ChamCongs { get; set;}
    }
}
