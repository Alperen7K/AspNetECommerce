using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.DTO_s;

namespace Business.Abstract;

public interface IUserOperationClaimService
{
    IResult Add(AddUserOperationClaimDto addUserOperationClaimDto);

    IResult Delete(UserOperationClaim userOperationClaim);

    IDataResult<UserOperationClaim> Update(UserOperationClaim userOperationClaim);

    IDataResult<List<UserOperationClaimDetailDto>> GetUserOperationClaimsByUserId(int id);
}