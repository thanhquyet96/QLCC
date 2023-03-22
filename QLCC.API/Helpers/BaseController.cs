using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCC.Entities;
using QLCC.ViewModels;

namespace QLCC.Helpers
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
            var user = (User)_httpContextAccessor.HttpContext.Items["User"];
            if (user != null)
            {
                UserIdentity = new UserIdentity(user);
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
