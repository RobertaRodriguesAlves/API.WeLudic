using FluentValidation;

namespace WeLudic.Application.Requests.Auth;

public sealed class SignUpValidator : AbstractValidator<SignUpRequest>
{
    public SignUpValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty()
            .WithMessage("{Property} cannot be empty.");

        RuleFor(user => user.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email is invalid.");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("{Property} cannot be empty.")
            .MinimumLength(8).WithMessage("{Property} must be at least 8 characters.")
            .Matches(@"[A-Z]+").WithMessage("{Property} must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("{Property} must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("{Property} must contain at least one number.")
            .Matches(@"[\!\?\*\.]+").WithMessage("{Property} must contain at least one (!? *.).");
    }
}
