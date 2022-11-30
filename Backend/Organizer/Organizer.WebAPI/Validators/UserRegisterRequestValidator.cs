using FluentValidation;
using Organizer.Models.Auth;

namespace Organizer.Validators;

public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
        RuleFor(x => x.Password)
            .NotEmpty()
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&\.,:;])[A-Za-z\d@$!%*#?&\.,:;]+$");
    }
}