using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete;

public class UserOperationClaimManager : IUserOperationClaimService
{
    private IUserOperationClaimDal _userOperationClaimDal;

    public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
    {
        _userOperationClaimDal = userOperationClaimDal;
    }

    public IResult Add(UserOperationClaim userOperationClaim)
    {
        IResult result = BusinessRules.Run(UserOperationClaimExist(userOperationClaim.UserId));

        if (result != null) return result;

        _userOperationClaimDal.Add(userOperationClaim);
        return new SuccessResult(Messages.UserOperationClaimAdded);
    }

    public IResult Delete(UserOperationClaim userOperationClaim)
    {
        _userOperationClaimDal.Delete(userOperationClaim);
        return new SuccessResult(Messages.UserOperationClaimDeleted);
    }

    public IDataResult<UserOperationClaim> Update(UserOperationClaim userOperationClaim)
    {
        _userOperationClaimDal.Update(userOperationClaim);

        var result = _userOperationClaimDal.Get(u => u.UserId == userOperationClaim.UserId);

        return new SuccessDataResult<UserOperationClaim>(result, Messages.UserOperationClaimUpdated);
    }

    public IDataResult<UserOperationClaim> GetByUserId(int id)
    {
        var result = _userOperationClaimDal.Get(u => u.UserId == id);

        return new SuccessDataResult<UserOperationClaim>(result, Messages.UserOperationClaimGetted);
    }

    public IResult UserOperationClaimExist(int userId)
    {
        var userOperationClaim = _userOperationClaimDal.Get(x => x.UserId == userId);

        if (userOperationClaim != null)
        {
            return new ErrorResult(Messages.UserOperationClaimExist);
        }

        return new SuccessResult();
    }
}