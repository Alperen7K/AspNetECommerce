using Entities.DTO_s;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public ActionResult Register(UserForRegisterDto userForRegisterDto)
    {
        var userExist = _authService.UserExists(userForRegisterDto.Email);
        if (!userExist.Success)
        {
            return BadRequest(userExist.Message);
        }

        _authService.Register(userForRegisterDto, userForRegisterDto.Password);

        return Ok(userExist.Message);
    }
}