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
            .WithMessage("Password cannot be empty.");
    }
}
