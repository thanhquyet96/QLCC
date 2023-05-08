using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCC.Services.Dtos.User;

namespace QLCC.WebApi.Helpers
{
    public class BaseController : ControllerBase
    {
        public UserIdentity UserIdentity;
        private readonly IHttpContextAccessor _httpContextAccessor;


        //public BaseController(IHttpContextAccessor httpContextAccessor) =>
        //    _httpContextAccessor = httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            LoadUserIdentity();
        }
        private void LoadUserIdentity()
        {
            var user = (UserResultDto)_httpContextAccessor.HttpContext.Items["User"];
            var roles = (List<string>)_httpContextAccessor.HttpContext.Items["Roles"];
            if (user != null)
            {

                UserIdentity = new UserIdentity()
                {
                    Id = user.Id,
                    IsAdmin = false,
                    Name = user.FullName,
                    Privilges = user.Roles,
                    Username = user.UserName

                };
            }
        }

        //public BaseController()
        //{
        //    var user = (User)HttpContext.Items["User"];
        //    if (user != null)
        //    {
        //        UserIdentity = new UserIdentity(user);
        //    }
        //}
    }
}
