using FluentValidation;

namespace WeLudic.Application.Requests.Auth;

public sealed class RefreshAuthenticationRequestValidator : AbstractValidator<RefreshAuthenticationRequest>
{
    public RefreshAuthenticationRequestValidator()
    {
        RuleFor(p => p.RefreshToken)
            .NotEmpty()
            .NotNull()
            .WithMessage("É necessário informar um refreshtoken");
    }
}
