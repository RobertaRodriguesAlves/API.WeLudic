using FluentValidation;

namespace WeLudic.Application.Requests.Auth;

public sealed class SignInValidator : AbstractValidator<SignInRequest>
{
    public SignInValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Informe um e-mail")
            .EmailAddress()
            .WithMessage("E-mail inválido");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("Informe uma senha");
    }
}