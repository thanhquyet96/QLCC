using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QLCC.Entities;
using QLCC.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace QLCC.Models
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private DataContext _db;
        public UserService(IOptions<AppSettings> appSettings, DataContext db)
        {
            _appSettings = appSettings.Value;
            _db = db;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _db.Users.SingleOrDefault(x => x.TaiKhoan == model.Username && x.MatKhau == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.AsEnumerable();
        }

        public User GetById(int id)
        {
            return _db.Users.Include(x=>x.NhanVien_Quyens).FirstOrDefault(x => x.Id == id);
        }

        private List<Claim> GetQuyens(User user)
        {
            IdentityOptions _options = new IdentityOptions();

            var claims = new List<Claim>
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
                    new Claim(_options.ClaimsIdentity.UserNameClaimType, user.TaiKhoan),
                };
            var data = _db.NhanVien_Quyen.Where(x => x.NhanVienId == user.Id).Include(x=>x.Quyen).ToList();
            foreach (var item in data)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Quyen?.TenQuyen));
            }

            return claims;
        }
        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = GetQuyens(user);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
