using FluentValidation;

namespace WeLudic.Application.Requests.Auth;

public sealed class RefreshAuthenticationRequestValidator : AbstractValidator<RefreshAuthenticationRequest>
{
    public RefreshAuthenticationRequestValidator()
    {
        RuleFor(refresh => refresh.ExpiredAccessToken).NotEmpty();
        RuleFor(refresh => refresh.RefreshToken).NotEmpty();
    }
}
