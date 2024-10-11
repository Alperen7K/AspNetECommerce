using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IOperationClaimService
{
    IDataResult<OperationClaim> Get(int id);

    IResult Add(OperationClaim operationClaim);

    IDataResult<OperationClaim> Update(OperationClaim operationClaim);

    IResult Delete(OperationClaim operationClaim);

    IDataResult<List<OperationClaim>> GetAll();

    IResult OperationClaimExist(string operationClaimName);
    IResult OperationClaimExistById(int id);
}