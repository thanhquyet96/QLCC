namespace QLCC.Entities
{
    public class Quyen
    {
        public int Id { get; set; }
        public string TenQuyen { get; set; }
        public virtual ICollection<NhanVien_Quyen> NhanVien_Quyens { get; set;}
    }
}
