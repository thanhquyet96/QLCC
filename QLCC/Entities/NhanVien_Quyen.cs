using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Entities
{
    public class NhanVien_Quyen
    {
        [Key]
        [Column(Order = 1)]
        public int? NhanVienId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int? QuyenId { get; set; }
    }
}
