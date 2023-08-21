using WeLudic.Shared.Requests;

namespace WeLudic.Application.Requests.Auth;

public sealed class RefreshAuthenticationRequest : BaseRequestWithValidation
{
    public RefreshAuthenticationRequest(string refreshToken)
    {
        RefreshToken = refreshToken;
    }

    public string RefreshToken { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<RefreshAuthenticationRequestValidator>(this);
}