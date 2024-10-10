using Abstract.Concrete;
using Entities.DTO_s;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : Controller
{
    private IAuthService _authService;
    private IOperationClaimService _operationClaimService;

    public AuthController(IAuthService authService, IOperationClaimService operationClaimService)
    {
        _authService = authService;
        _operationClaimService = operationClaimService;
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

    [HttpPost("login")]
    public ActionResult Login(UserForLoginDto userForLoginDto)
    {
        var userToLoogin = _authService.Login(userForLoginDto);
        if (!userToLoogin.Success)
        {
            return Ok(userToLoogin);
        }

        return Ok(_authService.CreateAccessToken(userToLoogin.Data));
    }
}