using FluentValidation;

namespace WeLudic.Application.Requests.Auth;

public sealed class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
{
    public AuthenticationRequestValidator()
    {
        RuleFor(auth => auth.ApiKey).NotEmpty();
    }
}
