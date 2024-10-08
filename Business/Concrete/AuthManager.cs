using Entities.DTO_s;
using Abstract.Concrete;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Security.Jwt;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Business.ValidationRules.FluentValidation.Auth;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private IUserService _userService;
    private ITokenHelper _tokenHelper;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
    }

    [ValidationAspect(typeof(RegisterValidator))]
    public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
    {
        IResult result = BusinessRules.Run(UserExists(userForRegisterDto.Email));
        if (result != null)
        {
            return new ErrorDataResult<User>(result.Message);
        }

        byte[] passwordHash, passwordSalt;

        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

        var user = new User
        {
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
        };

        _userService.Add(user);

        return new SuccessDataResult<User>(user, Messages.UserRegistered);
    }

    public IDataResult<User> Login(UserForLoginDto userForLoginDto)
    {
        throw new NotImplementedException();
    }

    public IResult UserExists(string email)
    {
        var user = _userService.GetByEmail(email);
        if (user != null)
        {
            return new ErrorResult(Messages.UserAlreadyRegistered);
        }

        return new SuccessResult(Messages.UserNotFound);
    }

    public IDataResult<AccessToken> CreateAccessToken(User user)
    {
        throw new NotImplementedException();
    }
}