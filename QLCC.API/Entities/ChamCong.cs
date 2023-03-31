using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Entities
{
    public class ChamCong
    {
        public int Id { get; set; }
        //public string Ten { get; set; }
        public int? NhanVienId { get; set; }
        public int? NgayChamCongId { get; set; }
        [ForeignKey("NgayChamCongId")]
        [InverseProperty("ChamCongs")]
        public virtual NgayChamCong NgayChamCong { get; set; }


        [ForeignKey("NhanVienId")]
        [InverseProperty("ChamCongs")]
        public virtual User NhanVien { get; set; }
    }
}
