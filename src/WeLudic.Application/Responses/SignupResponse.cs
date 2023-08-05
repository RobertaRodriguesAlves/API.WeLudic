using WeLudic.Shared.Responses;

namespace WeLudic.Application.Responses;

public sealed class SignupResponse : BaseResponse
{
    public SignupResponse(TokenResponse accessKeys, UserResponse user)
    {
        AccessKeys = accessKeys;
        User = user;
    }

    public TokenResponse AccessKeys { get; }
    public UserResponse User { get; }
}
