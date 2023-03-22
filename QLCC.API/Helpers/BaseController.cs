using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCC.Entities;
using QLCC.ViewModels;

namespace QLCC.Helpers
{
    public class BaseController : ControllerBase
    {
        public UserIdentity UserIdentity;
        private HttpContext _context;
        public BaseController() { }
        public BaseController(HttpContext context)
        {
            var user = (User)context.Items["User"];
            if (user != null)
            {
                UserIdentity = new UserIdentity(user);
            }
        }
    }
}
