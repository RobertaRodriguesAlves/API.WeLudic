using WeLudic.Shared.Requests;

namespace WeLudic.Application.Requests.Auth;

public sealed class RefreshAuthenticationRequest : BaseRequestWithValidation
{
    public RefreshAuthenticationRequest(Guid id, string refreshToken)
    {
        Id = id;
        RefreshToken = refreshToken;
    }

    public Guid Id { get; }
    public string RefreshToken { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<RefreshAuthenticationRequestValidator>(this);
}