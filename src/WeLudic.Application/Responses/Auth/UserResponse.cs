namespace WeLudic.Application.Responses.Auth;

public sealed class UserResponse
{
    public UserResponse(Guid? id, string name, string email, bool accordingToTerms)
    {
        Id = id;
        Name = name;
        Email = email;
        ConfirmAndAgree = accordingToTerms;
    }

    public Guid? Id { get; }
    public string Name { get; }
    public string Email { get; }
    public bool ConfirmAndAgree { get; }
}