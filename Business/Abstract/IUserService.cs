using Core.Entities.Concrete;

namespace Abstract.Concrete;

public interface IUserService
{
    void Add(User user);

    User GetByEmail(string email);
    
    List<OperationClaim> GetClaims(User user);
    
    User GetProfil(int id);
}