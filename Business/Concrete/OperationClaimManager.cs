using Business.Abstract;
using Business.Constants;
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

    public IDataResult<OperationClaim> Get(int id)
    {
        var result=_operationClaimDal.Get(x => x.Id == id);
        if (result != null)
        {
            return new SuccessDataResult<OperationClaim>(result,Messages.OperationClaimGetted);
        }
        return new ErrorDataResult<OperationClaim>(Messages.OperationClaimNotFound);
    }

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

    public IDataResult<OperationClaim> Update(OperationClaim operationClaim)
    {
        _operationClaimDal.Update(operationClaim);

        var modifiedData = _operationClaimDal.Get(c => c.Id == operationClaim.Id);
        return new SuccessDataResult<OperationClaim>(modifiedData, Messages.OperationClaimUpdated);
    }

    public IResult Delete(OperationClaim operationClaim)
    {
        _operationClaimDal.Delete(operationClaim);
        return new SuccessResult(Messages.OperationClaimDeleted);
    }

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
}