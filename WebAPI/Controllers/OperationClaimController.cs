using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("auth/operation-claims")]
[ApiController]
public class OperationClaimController : Controller
{
    private IOperationClaimService _operationClaimService;

    public OperationClaimController(IOperationClaimService operationClaimService)
    {
        _operationClaimService = operationClaimService;
    }

    [HttpGet("{id}")]
    public ActionResult GetOperationClaim(int id)
    {
        return Ok(_operationClaimService.Get(id));
    }

    [HttpGet]
    public ActionResult GetAllOperationClaims()
    {
        return Ok(_operationClaimService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult CreateOperationClaim(OperationClaim operationClaim)
    {
        return Ok(_operationClaimService.Add(operationClaim));
    }

    [HttpPut]
    public ActionResult UpdateOperationClaim(OperationClaim operationClaim)
    {
        return Ok(_operationClaimService.Update(operationClaim));
    }

    [HttpDelete]
    public ActionResult DeleteOperationClaim(OperationClaim operationClaim)
    {
        return Ok(_operationClaimService.Delete(operationClaim));
    }
}