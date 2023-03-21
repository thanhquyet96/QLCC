using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QLCC.Entities;

namespace QLCC.Helpers
{
    //[AttributeUsage(AttributeTargets.Method)]
    //public class AllowAnonymousAttribute : Attribute
    //{ }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<string> _roles;

        public AuthorizeAttribute(params string[] roles)
        {
            _roles = roles ?? new string[] { };
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            //if (allowAnonymous)
            //    return;

            // authorization
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in or role not authorized
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            var roles = (List<string>)context.HttpContext.Items["Roles"];
            if(roles == null || roles.Count == 0)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else if (roles.Any() && _roles.Any())
            {

                var isAuth = false;

                var a = roles.Any(x => _roles.Contains(x));
                //foreach (var role in roles)
                //{
                //    var isRole = _roles.Count(x => x == role);
                //    if (isRole == 0)
                //    {
                //        isAuth = true;
                //    }
                //    else
                //    {
                //        isAuth = false;
                //    }
                //}
                if(!a)
                {
                    context.Result = new JsonResult(new { message = "Bạn không có quyền truy cập chức năng này!" }) { StatusCode = StatusCodes.Status403Forbidden };
                }
                //context.Result = new JsonResult(new { message = "Bạn không có quyền truy cập chức năng này!" }) { StatusCode = StatusCodes.Status403Forbidden };
            }
            else
            {
                
            }

        }
    }
}
