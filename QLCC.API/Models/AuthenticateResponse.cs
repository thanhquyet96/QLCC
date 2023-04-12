using QLCC.Entities;

namespace QLCC.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string HoVaTen { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            HoVaTen = user.HoVaTen;
            Username = user.TaiKhoan;
            Token = token;
            Roles = user.NhanVien_Quyens?.Select(x => x.Quyen.TenQuyen).ToList();
        }
    }
}
