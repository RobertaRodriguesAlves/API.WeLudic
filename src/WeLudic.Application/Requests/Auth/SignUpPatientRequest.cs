using WeLudic.Shared.Requests;

namespace WeLudic.Application.Requests.Auth;

public sealed class SignUpPatientRequest : BaseRequestWithValidation
{
    public SignUpPatientRequest(string name, Guid sessionId, bool confirmAndAgree)
    {
        Name = name;
        SessionId = sessionId;
        ConfirmAndAgree = confirmAndAgree;
    }

    public string Name { get; }
    public Guid SessionId { get; set; }
    public bool ConfirmAndAgree { get; }

    public override async Task ValidateAsync()
       => ValidationResult = await LazyValidator.ValidateAsync<SignUpPatientValidator>(this);
}