using WeLudic.Domain.ValueObjects;
using WeLudic.Shared.Requests;

namespace WeLudic.Application.Requests.Auth;

public sealed class SignInRequest : BaseRequestWithValidation
{
    public SignInRequest(
        Email email,
        string password)
    {
        Email = email;
        Password = password;
    }

    public Email Email { get; }
    public string Password { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<SignInValidator>(this);
}