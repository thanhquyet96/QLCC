using QLCC.Entities;

namespace QLCC.ViewModels
{
    public class UserIdentity
    {
        public UserIdentity() { }
        public UserIdentity(User user) {
            Id = user.Id;
            Name = user.HoVaTen;
            Username = user.TaiKhoan;
            Privilges = user.NhanVien_Quyens?.Select(x => x.Quyen?.TenQuyen).ToList();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public IEnumerable<string> Privilges { get; set; }
        public bool IsAdmin { get; set; }
    }
}
