using WeLudic.Domain.Entities.Common;

namespace WeLudic.Domain.Entities;

public class Patient : BaseSecurityEntity
{
    public string Name { get; private set; }
    public bool ConfirmAndAgree { get; private set; }
    public Guid RouletteSessionId { get; private set; }
    public virtual RouletteSession RouletteSessions { get; }

    public Patient SetPatient(string name, Guid rouletteSessionId, bool confirmAndAgree)
    {
        Name = name;
        ConfirmAndAgree = confirmAndAgree;
        RouletteSessionId = rouletteSessionId;
        return this;
    }
}
