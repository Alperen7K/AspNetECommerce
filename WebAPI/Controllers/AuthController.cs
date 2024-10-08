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
        var register = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

        if (!register.Success)
        {
            return BadRequest(register);
        }

        return Ok(register);
    }
}