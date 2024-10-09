using Entities.DTO_s;
using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
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

    [HttpGet("operation-claim/get")]
    public ActionResult GetOperationClaim(int id)
    {
        return Ok(_operationClaimService.Get(id));
    }

    [HttpGet("operation-claim/get-all")]
    public ActionResult GetAllOperationClaims()
    {
        return Ok(_operationClaimService.GetAll());
    }

    [HttpPost("operation-claim/create")]
    public ActionResult CreateOperationClaim(OperationClaim operationClaim)
    {
        return Ok(_operationClaimService.Add(operationClaim));
    }

    [HttpPut("operation-claim/update")]
    public ActionResult UpdateOperationClaim(OperationClaim operationClaim)
    {
        return Ok(_operationClaimService.Update(operationClaim));
    }

    [HttpDelete("operation-claim/delete")]
    public ActionResult DeleteOperationClaim(OperationClaim operationClaim)
    {
        return Ok(_operationClaimService.Delete(operationClaim));
    }
}