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
using DataAccess.Abstract;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private IUserService _userService;
    private IUserOperationClaimService _userOperationClaimService;
    private ITokenHelper _tokenHelper;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper,
        IUserOperationClaimService userOperationClaimService)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userOperationClaimService = userOperationClaimService;
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

        var userOperationClaim = new UserOperationClaim
        {
            UserId = _userService.GetByEmail(user.Email).Id, OperationClaimId = 7
        }; // OperationClaimId = 6 is default 'customer' claim

        _userOperationClaimService.Add(userOperationClaim);

        return new SuccessDataResult<User>(user, Messages.UserRegistered);
    }

    [ValidationAspect(typeof(LoginValidator))]
    public IDataResult<User> Login(UserForLoginDto userForLoginDto)
    {
        var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
        if (userToCheck == null)
        {
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }

        if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash,
                userToCheck.PasswordSalt))
        {
            return new ErrorDataResult<User>(Messages.PasswordError);
        }

        return new SuccessDataResult<User>(userToCheck, Messages.SuccessfullLogin);
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
        var claims = _userService.GetClaims(user);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
    }
}