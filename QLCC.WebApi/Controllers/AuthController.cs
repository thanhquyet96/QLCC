using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLCC.Services;
using QLCC.Services.Dtos.User;

namespace QLCC.WebApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthController : ControllerBase
{
    private UserServices _userServices;

    public AuthController(UserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Authenticate([FromBody] UserLoginDto model)
    {
        var response = await _userServices.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto model)
    {
        if (ModelState.IsValid)
        {
            var response = await _userServices.RegisterUser(model);

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



    ////[Authorize]
    //[HttpGet("GetAll")]
    //public IActionResult GetAll()
    //{
    //    //var users = _userServices.GetAll();
    //    return Ok(users);
    //}
    //[HttpGet("Get")]
    //public IActionResult GetDetail()
    //{
    //    return Ok();
    //}
}