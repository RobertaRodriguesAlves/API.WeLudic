using WeLudic.Shared.Requests;

namespace WeLudic.Application.Requests.Auth;

public sealed class SignUpRequest : BaseRequestWithValidation
{
    public SignUpRequest(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public string Name { get; }
    public string Email { get; }
    public string Password { get; }

    public override async Task ValidateAsync()
       => ValidationResult = await LazyValidator.ValidateAsync<SignUpValidator>(this);
}