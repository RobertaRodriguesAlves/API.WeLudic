using WeLudic.Domain.Entities.Common;
using WeLudic.Domain.ValueObjects;

namespace WeLudic.Domain.Entities;
public sealed class User : BaseAuditEntity
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public string HashedPassword { get; private set; }

    public User SetUser(string name, Email email, string password)
    {
        Name = name;
        Email = email;
        HashedPassword = password;
        return this;
    }
}
