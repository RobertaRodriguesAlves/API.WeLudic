using FluentValidation;

namespace WeLudic.Application.Requests.Auth;

public sealed class SignInValidator : AbstractValidator<SignInRequest>
{
    public SignInValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("{Property} cannot be empty.");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("{Property} cannot be empty.");
    }
}