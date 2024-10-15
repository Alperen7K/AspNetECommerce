using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Abstract.Concrete;

public interface IUserService
{
    void Add(User user);

    User GetByEmail(string email);

    List<OperationClaim> GetClaims(User user);

    IResult IsUserExistById(int id);

    User GetProfil(int id);
}