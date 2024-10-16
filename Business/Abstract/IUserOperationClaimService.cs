using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.DTO_s;

namespace Business.Abstract;

public interface IUserOperationClaimService
{
    IResult Add(int userId, int operationClaimId);
    IResult MultipleAdd(AddUserOperationClaimDto addUserOperationClaimDto);

    IResult Delete(int id);

    IDataResult<UserOperationClaim> Update(UserOperationClaim userOperationClaim);

    IDataResult<List<UserOperationClaimDetailDto>> GetUserOperationClaimsByUserId(int id);
    
    IResult UserOperationClaimExist(int userId, int operationClaimId);
}