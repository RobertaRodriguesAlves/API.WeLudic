using WeLudic.Shared.Requests;

namespace WeLudic.Application.Requests.Auth;

public sealed class SignUpRequest : BaseRequestWithValidation
{
    public SignUpRequest(string name, string email, string password, string confirmPassword, bool accordingToTerms)
    {
        Name = name;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
        AccordingToTerms = accordingToTerms;
    }

    public string Name { get; }
    public string Email { get; }
    public string Password { get; }
    public string ConfirmPassword { get; }
    public bool AccordingToTerms { get; }

    public override async Task ValidateAsync()
       => ValidationResult = await LazyValidator.ValidateAsync<SignUpValidator>(this);
}