using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLCC.Helpers;
using QLCC.Models;

namespace QLCC.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Authenticate([FromBody]AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _userService.RegisterUser(model);

                if (response == 0)
                    return Ok(new { message = "Thêm mới thành công!" });
                else
                    return Ok(new { message = "Tài khoản đã tồn tại!" });


            }

            return BadRequest();
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Items.Clear();
            return Ok();
        }



        //[Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        [HttpGet("Get")]
        public IActionResult GetDetail()
        {
            return Ok();
        }
    }
}
