using WeLudic.Domain.Entities.Common;

namespace WeLudic.Domain.Entities;

public class Patient : BaseSecurityEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public bool ConfirmAndAgree { get; private set; }
    public Guid UserId { get; private set; }
    public virtual User User { get; }

    public Patient SetPatient(string name, string email, bool confirmAndAgree, Guid userid)
    {
        Name = name;
        Email = email;
        ConfirmAndAgree = confirmAndAgree;
        UserId = userid;
        return this;
    }
}
