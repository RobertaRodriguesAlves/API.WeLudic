using FluentValidation;

namespace WeLudic.Application.Requests.Auth;

public sealed class SignUpValidator : AbstractValidator<SignUpRequest>
{
    public SignUpValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty()
            .WithMessage("Informe um nome");

        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Informe um e-mail")
            .EmailAddress()
            .WithMessage("E-mail inválido");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("Informe uma senha");

        RuleFor(user => user.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirme a senha");

        RuleFor(user => user)
            .Must(opt => ConfirmPassword(opt.Password, opt.ConfirmPassword))
            .WithMessage("Os campos de senha não conferem");

        RuleFor(user => user.ConfirmAndAgree)
            .Equal(true)
            .WithMessage("É necessário concordar com os termos");
    }

    private static bool ConfirmPassword(string password, string confirmPassword)
        => password.Equals(confirmPassword);
}
