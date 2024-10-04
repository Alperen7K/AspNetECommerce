using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Jwt;
using Entities.DTO_s;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private IUserService _userService;
    private ITokenHelper _tokenHelper;

    public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
    {
        throw new NotImplementedException();
    }

    public IDataResult<User> Login(UserForLoginDto userForLoginDto)
    {
        throw new NotImplementedException();
    }

    public IResult UserExists(string email)
    {
        throw new NotImplementedException();
    }

    public IDataResult<AccessToken> CreateAccessToken(User user)
    {
        throw new NotImplementedException();
    }
}