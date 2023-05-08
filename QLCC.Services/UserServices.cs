using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Common;
//using Common.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QLCC.Data;
using QLCC.Data.Entities;
using QLCC.Services.Dtos.User;
using QLCC.Services.Helpers.JWT;
using Repository;
using Service;
using UnitOfWork;

namespace QLCC.Services
{
    public class UserServices : QLCCBaseServices<USER>
    {
        private readonly ILogger<UserServices> _logger;
        //private readonly AppSettings _appSettings;
        private JwtUtils _jwtUtils;
        private IUnitOfWork<QLCCContext> _unitOfWork;
       
        public UserServices(IRepository<QLCCContext, USER> repository, IMapper mapper, ILogger<UserServices> logger, IOptions<AppSettings> appSettings, IUnitOfWork<QLCCContext> unitOfWork) : base(repository, mapper, logger, unitOfWork)
        {
            _logger = logger;
            //_appSettings = appSettings.Value;
            _jwtUtils = new JwtUtils(appSettings);
            _unitOfWork = unitOfWork;
        }
        public async Task<PagingResult<UserGridDto>> GetUsers(UserGridPagingDto pagingModel)
        {
            _logger.LogInformation("Danh sách Yser");
            base._logger.LogInformation("Base Parent");
            return await base.FilterPage<UserGridDto>(pagingModel);
        }


        //public async Task<UserGridDto> GetUsers()
        //{
        //    var model = base.Filter<UserGridDto>();
        //}

        public async Task Put(int id, UserUpdateDto user)
        {
            await base.Update<UserUpdateDto>(id, user);
            await _unitOfWork.Save();
        }

        public async Task Post(UserCreateDto user)
        {
            await base.Add<UserCreateDto>(user);
            await _unitOfWork.Save();
        }

        public async Task<UserResultDto> Authenticate(UserLoginDto model)
        {
            var user = await base.Get<UserResultDto>(x => x.UserName == model.Username && x.Password == model.Password);
            // return null if user not found
            if (user == null) return null;
            IdentityOptions _options = new IdentityOptions();

            var claims = new List<Claim>
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
                    new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName),
                };
            _jwtUtils.SetClaims(claims);
            // authentication successful so generate jwt token
            var token = _jwtUtils.GenerateJwtToken<UserResultDto>(user);
            user.Token = token;
            return user;
        }

        //public IEnumerable<User> GetAll()
        //{
        //    return _db.Users.AsEnumerable();
        //}

        //public User GetById(int id)
        //{
        //    return _db.Users.Include(x => x.NhanVien_Quyens).FirstOrDefault(x => x.Id == id);
        //}

        public async Task<int> RegisterUser(UserRegisterDto model)
        {
            var isExist = await IsExistUserName(model.Username);
            if (isExist == false)
            {
                //_db.Users.Add(new User()
                //{
                //    FullName = model.FullName,
                //    TaiKhoan = model.Username,
                //    MatKhau = model.Password,
                //    HeSoLuong = 1,
                //});
                //_db.SaveChanges();

                await base.Add<UserRegisterDto>(model);
                await _unitOfWork.Save();
                return 0;
            }
            // TH Tài khoản đã tồn tại
            else
            {
                return -1;
            }
        }

        public async Task Delete(int id)
        {
            await base.Delete(id);
            await _unitOfWork.Save();
        }

        private async Task<bool> IsExistUserName(string userName)
        {
            return await base.ContainAsync<UserResultDto>(x => x.UserName == userName);
        }

        public async Task<UserResultDto> Get(int id)
        {
            return await base.Find<UserResultDto>(id);
        }

        //private List<Claim> GetRoles(UserResultDto user)
        //{
        //    IdentityOptions _options = new IdentityOptions();

        //    var claims = new List<Claim>
        //        {
        //            new Claim("Id", user.Id.ToString()),
        //            new Claim(ClaimTypes.Sid, user.Id.ToString()),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //            new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
        //            new Claim(_options.ClaimsIdentity.UserNameClaimType, user.TaiKhoan),
        //        };
        //    var data = _db.NhanVien_Quyen.Where(x => x.USER_ID == user.Id).Include(x => x.Quyen).ToList();
        //    foreach (var item in data)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, item.Quyen?.TenQuyen));
        //    }

        //    return claims;
        //}
        //// helper methods

        //private string generateJwtToken(UserResultDto user)
        //{
        //    // generate token that is valid for 7 days
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var claims = GetRoles(user);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
    }
}

