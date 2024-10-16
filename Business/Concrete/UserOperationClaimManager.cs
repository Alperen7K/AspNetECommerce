using Abstract.Concrete;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTO_s;

namespace Business.Concrete;

public class UserOperationClaimManager : IUserOperationClaimService
{
    private IUserOperationClaimDal _userOperationClaimDal;
    private IOperationClaimService _operationClaimService;
    private IUserService _userService;

    public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IUserService userService,
        IOperationClaimService operationClaimService)
    {
        _userService = userService;
        _userOperationClaimDal = userOperationClaimDal;
        _operationClaimService = operationClaimService;
    }

    public IResult Add(int userId, int operationClaimId)
    {
        _userOperationClaimDal.Add(new UserOperationClaim
            { UserId = userId, OperationClaimId = operationClaimId });

        return new SuccessResult(Messages.UserOperationClaimAdded);
    }

    [ValidationAspect(typeof(MultipleUserOperationClaimValidator))]
    public IResult MultipleAdd(AddUserOperationClaimDto addUserOperationClaimDto)
    {
        IResult result = BusinessRules.Run(_userService.IsUserExistById(addUserOperationClaimDto.UserId),
            _operationClaimService.OperationClaimExistByIds(addUserOperationClaimDto.OperationClaimIds));

        if (!result.Success) return new ErrorResult(result.Message);

        foreach (var operationClaimId in addUserOperationClaimDto.OperationClaimIds)
        {
            var isUserOperationClaimExist = UserOperationClaimExist(addUserOperationClaimDto.UserId, operationClaimId);

            if (isUserOperationClaimExist.Success)
                return new ErrorResult(isUserOperationClaimExist.Message);

            Add(addUserOperationClaimDto.UserId, operationClaimId);
        }

        return new SuccessResult(Messages.UserOperationClaimAdded);
    }

    public IResult Delete(int id)
    {
        var result = _userOperationClaimDal.Get(c => c.Id == id);

        if (result == null) return new ErrorResult(Messages.UserOperationClaimNotFound);

        _userOperationClaimDal.Delete(result);

        return new SuccessResult(Messages.UserOperationClaimDeleted);
    }

    public IDataResult<UserOperationClaim> Update(UserOperationClaim userOperationClaim)
    {
        _userOperationClaimDal.Update(userOperationClaim);

        var result = _userOperationClaimDal.Get(u => u.UserId == userOperationClaim.UserId);

        return new SuccessDataResult<UserOperationClaim>(result, Messages.UserOperationClaimUpdated);
    }

    public IDataResult<List<UserOperationClaimDetailDto>> GetUserOperationClaimsByUserId(int id)
    {
        IResult result = BusinessRules.Run(_userService.IsUserExistById(id));

        if (!result.Success) return new ErrorDataResult<List<UserOperationClaimDetailDto>>(result.Message);

        return new SuccessDataResult<List<UserOperationClaimDetailDto>>(
            _userOperationClaimDal.GetUserOperationClaimsByUserId(id), Messages.UserOperationClaimGetted);
    }

    public IResult UserOperationClaimExist(int userId, int operationClaimId)
    {
        var isUserOperationClaimExist =
            _userOperationClaimDal.Get(x => x.UserId == userId && x.OperationClaimId == operationClaimId);

        if (isUserOperationClaimExist != null) return new SuccessResult(Messages.UserOperationClaimExist);

        return new ErrorResult(Messages.UserOperationClaimNotFound);
    }
}