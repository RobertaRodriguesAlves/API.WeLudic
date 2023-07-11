using WeLudic.Shared.Requests;

namespace WeLudic.Application.Requests.Auth;

public sealed class AuthenticationRequest : BaseRequestWithValidation
{
    public AuthenticationRequest(Guid apiKey) => ApiKey = apiKey;

    public Guid ApiKey { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AuthenticationRequestValidator>(this);
}