using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete;

public class OperationClaimManager : IOperationClaimService
{
    IOperationClaimDal _operationClaimDal;

    public OperationClaimManager(IOperationClaimDal operationClaimDal)
    {
        _operationClaimDal = operationClaimDal;
    }

    // [SecuredOperations("SuperAdmin")]
    public IDataResult<OperationClaim> Get(int id)
    {
        var result = _operationClaimDal.Get(x => x.Id == id);
        if (result != null)
        {
            return new SuccessDataResult<OperationClaim>(result, Messages.OperationClaimGetted);
        }

        return new ErrorDataResult<OperationClaim>(Messages.OperationClaimNotFound);
    }

    [SecuredOperations("SuperAdmin")]
    public IResult Add(OperationClaim operationClaim)
    {
        IResult result = BusinessRules.Run(OperationClaimExist(operationClaim.Name));

        if (result != null)
        {
            return new ErrorResult(result.Message);
        }

        _operationClaimDal.Add(operationClaim);

        return new SuccessResult(Messages.OperationClaimAdded);
    }

    [SecuredOperations("SuperAdmin")]
    public IDataResult<OperationClaim> Update(OperationClaim operationClaim)
    {
        _operationClaimDal.Update(operationClaim);

        var modifiedData = _operationClaimDal.Get(c => c.Id == operationClaim.Id);
        return new SuccessDataResult<OperationClaim>(modifiedData, Messages.OperationClaimUpdated);
    }

    [SecuredOperations("SuperAdmin")]
    public IResult Delete(OperationClaim operationClaim)
    {
        _operationClaimDal.Delete(operationClaim);
        return new SuccessResult(Messages.OperationClaimDeleted);
    }

    [SecuredOperations("SuperAdmin")]
    public IDataResult<List<OperationClaim>> GetAll()
    {
        return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(), Messages.OperationClaimListed);
    }

    public IResult OperationClaimExist(string operationClaimName)
    {
        var operationClaim = _operationClaimDal.Get(c => c.Name == operationClaimName);
        if (operationClaim != null)
        {
            return new ErrorResult(Messages.OperationClaimExist);
        }

        return new SuccessResult();
    }

    public IResult OperationClaimExistByIds(int[] ids)
    {
        List<int> absentIds = new List<int>();

        foreach (var id in ids)
        {
            var result = _operationClaimDal.Get(c => c.Id == id);
            if (result == null) absentIds.Add(id);
        }

        if (absentIds.Count == 0) return new SuccessDataResult<List<int>>(Messages.OperationClaimExist);

        return new ErrorDataResult<List<int>>(absentIds, Messages.OperationClaimNotFound);
    }
}