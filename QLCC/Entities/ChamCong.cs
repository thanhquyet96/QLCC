namespace QLCC.Entities
{
    public class ChamCong
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public int? NhanVienId { get; set; }
        public int? NgayChamCongId { get; set; }
    }
}
