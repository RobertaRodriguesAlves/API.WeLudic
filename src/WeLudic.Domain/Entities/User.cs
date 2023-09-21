using WeLudic.Domain.Entities.Common;

namespace WeLudic.Domain.Entities;

public sealed class User : BaseSecurityEntity
{
    public User()
    {
        RouletteSessions = new HashSet<RouletteSession>();
        RouletteOptions = new HashSet<RouletteOption>();
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string HashedPassword { get; private set; }
    public bool ConfirmAndAgree { get; private set; }
    public ICollection<RouletteSession> RouletteSessions { get; }
    public ICollection<RouletteOption> RouletteOptions { get; }

    public User SetUser(string name, string email, string password)
    {
        Name = name;
        Email = email;
        HashedPassword = password;
        ConfirmAndAgree = true;
        return this;
    }
}