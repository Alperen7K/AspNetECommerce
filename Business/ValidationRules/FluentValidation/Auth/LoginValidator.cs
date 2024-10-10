using Entities.DTO_s;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Auth;

public class LoginValidator : AbstractValidator<UserForLoginDto>
{
    public LoginValidator()
    {
        RuleFor(login => login.Email).NotEmpty().WithMessage("Email is required...").EmailAddress()
            .WithMessage("Invalid Email Address.");

        RuleFor(login => login.Password).NotEmpty().WithMessage("Password is required...").NotNull();
    }
}