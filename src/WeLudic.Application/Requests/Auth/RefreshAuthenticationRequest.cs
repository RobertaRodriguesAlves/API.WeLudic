using WeLudic.Shared.Requests;

namespace WeLudic.Application.Requests.Auth;

public sealed class RefreshAuthenticationRequest : BaseRequestWithValidation
{
    public RefreshAuthenticationRequest(Guid userId, string refreshToken)
    {
        UserId = userId;
        RefreshToken = refreshToken;
    }

    public Guid UserId { get; }
    public string RefreshToken { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<RefreshAuthenticationRequestValidator>(this);
}