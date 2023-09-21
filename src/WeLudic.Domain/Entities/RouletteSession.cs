using WeLudic.Domain.Entities.Common;

namespace WeLudic.Domain.Entities;
public class RouletteSession : BaseAuditEntity
{
    public RouletteSession()
    {
        Patients = new HashSet<Patient>();
        RouletteSessionOptions = new HashSet<RouletteSessionOption>();
    }

    public Guid Id { get; private init; } = Guid.NewGuid();
    public Guid UserId { get; private set; }
    public virtual User User { get; }
    public ICollection<Patient> Patients { get; }
    public ICollection<RouletteSessionOption> RouletteSessionOptions { get; }

    public RouletteSession SetRouletteSession(Guid userId)
    {
        UserId = userId;
        return this;
    }
}
