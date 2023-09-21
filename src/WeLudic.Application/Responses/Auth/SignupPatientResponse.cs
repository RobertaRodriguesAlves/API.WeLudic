namespace WeLudic.Application.Responses.Auth;

public sealed class SignupPatientResponse
{
    public SignupPatientResponse(TokenResponse accessKeys, PatientResponse user)
    {
        AccessKeys = accessKeys;
        User = user;
    }

    public TokenResponse AccessKeys { get; }
    public PatientResponse User { get; }
}
