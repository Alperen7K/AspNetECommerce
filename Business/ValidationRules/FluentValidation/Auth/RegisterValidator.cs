using Entities.DTO_s;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Auth;

public class RegisterValidator : AbstractValidator<UserForRegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required...");
        RuleFor(user => user.Email).EmailAddress().WithMessage("Invalid email address.");


        RuleFor(user => user.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(user => user.FirstName)
            .Length(6, 30).WithMessage("First name must be between 6 and 30 characters.");


        RuleFor(user => user.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(user => user.LastName)
            .Length(6, 30).WithMessage("Last name must be between 6 and 30 characters.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}