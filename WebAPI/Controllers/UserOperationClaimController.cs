using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("auth/user-operation-claims")]
[ApiController]
public class UserOperationClaimController : Controller
{
    private IUserOperationClaimService _userOperationClaimService;

    public UserOperationClaimController(IUserOperationClaimService userOperationClaimService)
    {
        _userOperationClaimService = userOperationClaimService;
    }

    [HttpGet("{id}")]
    public ActionResult<UserOperationClaim> GetUserOperationClaim(int id)
    {
        return Ok(_userOperationClaimService.GetUserOperationClaimsByUserId(id));
    }

    [HttpPost]
    public ActionResult<UserOperationClaim> CreateUserOperationClaim(AddUserOperationClaimDto addUserOperationClaimDto)
    {
        return Ok(_userOperationClaimService.Add(addUserOperationClaimDto));
    }
}