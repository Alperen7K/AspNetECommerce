using Abstract.Concrete;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete;

public class UserManager : IUserService
{
    IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public void Add(User user)
    {
        _userDal.Add(user);
    }

    public User GetByEmail(string email)
    {
        return _userDal.Get(u => u.Email == email);
    }

    public List<OperationClaim> GetClaims(User user)
    {
        return _userDal.GetClaims(user);
    }

    public IResult IsUserExistById(int id)
    {
        var result = _userDal.Get(u => u.Id == id);
        if (result != null) return new SuccessResult();
        return new ErrorResult(Messages.UserNotFound);
    }

    public User GetProfil(int id)
    {
        throw new NotImplementedException();
    }
}