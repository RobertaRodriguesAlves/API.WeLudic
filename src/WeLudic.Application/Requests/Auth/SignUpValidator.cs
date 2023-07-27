using FluentValidation;

namespace WeLudic.Application.Requests.Auth;

public sealed class SignUpValidator : AbstractValidator<SignUpRequest>
{
    public SignUpValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty()
            .WithMessage("{Property} cannot be empty.");

        RuleFor(user => user.Email.Address)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email address is invalid.");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("{Property} cannot be empty.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
            .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
            .Matches(@"[\!\?\*\.]+").WithMessage("Password must contain at least one (!? *.).");
    }
}
