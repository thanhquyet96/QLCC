using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCC.Entities
{
    public class LichSuChamCong
    {
        public int Id { get; set; }
        public int NhanVienId { get; set; }
        public decimal ThoiGianChamCong { get; set; }
        public DateTime NgayChamCong { get; set; }
        [ForeignKey("NhanVienId")]
        public virtual User NhanVien { get; set; } 
    }
}
