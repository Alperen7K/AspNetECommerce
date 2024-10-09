using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IUserOperationClaimService
{
    IResult Add(UserOperationClaim userOperationClaim);

    IResult Delete(UserOperationClaim userOperationClaim);

    IDataResult<UserOperationClaim> Update(UserOperationClaim userOperationClaim);

    IDataResult<UserOperationClaim> GetByUserId(int id);

    IResult UserOperationClaimExist(int userId);
}