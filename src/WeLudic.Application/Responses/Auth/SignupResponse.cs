namespace WeLudic.Application.Responses.Auth;

public sealed class SignupResponse
{
    public SignupResponse(TokenResponse accessKeys, UserResponse user)
    {
        AccessKeys = accessKeys;
        User = user;
    }

    public TokenResponse AccessKeys { get; }
    public UserResponse User { get; }
}
