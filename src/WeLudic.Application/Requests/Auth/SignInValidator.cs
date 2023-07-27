using FluentValidation;

namespace WeLudic.Application.Requests.Auth;

public sealed class SignInValidator : AbstractValidator<SignInRequest>
{
    public SignInValidator()
    {
        RuleFor(user => user.Email.Address)
            .NotEmpty()
            .WithMessage("Email cannot be empty.");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty.");
    }
}