using FluentValidation;

namespace WeLudic.Application.Requests.Auth;

public sealed class SignUpPatientValidator : AbstractValidator<SignUpPatientRequest>
{
    public SignUpPatientValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Informe um nome");

        RuleFor(p => p)
            .Must(opt => NotEmpty(opt.SessionId))
            .WithMessage("É necessário o id da sessão");

        RuleFor(p => p.ConfirmAndAgree)
            .Equal(true)
            .WithMessage("É necessário concordar com os termos");
    }

    private static bool NotEmpty(Guid sessionId)
        => !sessionId.Equals(Guid.Empty);
}
