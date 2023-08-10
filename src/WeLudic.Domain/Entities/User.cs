using WeLudic.Domain.Entities.Common;

namespace WeLudic.Domain.Entities;
public sealed class User : BaseAuditEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string HashedPassword { get; private set; }
    public bool AccordingToTerms { get; private set; }

    public User SetUser(string name, string email, string password)
    {
        Name = name;
        Email = email;
        HashedPassword = password;
        AccordingToTerms = true;
        return this;
    }
}