namespace WeLudic.Application.Responses.Auth;

public sealed class PatientResponse
{
    public PatientResponse(Guid? id, string name, bool accordingToTerms)
    {
        Id = id;
        Name = name;
        ConfirmAndAgree = accordingToTerms;
    }

    public Guid? Id { get; }
    public string Name { get; }
    public bool ConfirmAndAgree { get; }
}