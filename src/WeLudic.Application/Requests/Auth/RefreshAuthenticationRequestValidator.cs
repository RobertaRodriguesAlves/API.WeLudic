using FluentValidation;

namespace WeLudic.Application.Requests.Auth;

public sealed class RefreshAuthenticationRequestValidator : AbstractValidator<RefreshAuthenticationRequest>
{
    public RefreshAuthenticationRequestValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().NotNull();
        RuleFor(p => p.RefreshToken).NotEmpty().NotNull();
    }
}
