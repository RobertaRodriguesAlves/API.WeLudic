using WeLudic.Shared.Requests;

namespace WeLudic.Application.Requests.Auth;

public sealed class RefreshAuthenticationRequest : BaseRequestWithValidation
{
    public RefreshAuthenticationRequest(string expiredAccessToken, string refreshToken)
    {
        ExpiredAccessToken = expiredAccessToken;
        RefreshToken = refreshToken;
    }

    public string ExpiredAccessToken { get; }
    public string RefreshToken { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<RefreshAuthenticationRequestValidator>(this);
}