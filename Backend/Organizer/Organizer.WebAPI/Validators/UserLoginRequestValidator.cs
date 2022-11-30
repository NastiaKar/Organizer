using FluentValidation;
using Organizer.Models.Auth;

namespace Organizer.Validators;

public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
{
    public UserLoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
        RuleFor(x => x.Password)
            .Length(6, 15)
            .NotEmpty();
    }
}