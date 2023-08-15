using WeLudic.Domain.Entities.Common;

namespace WeLudic.Domain.Entities;
public class RouletteSession : BaseAuditEntity
{
    public RouletteSession()
    {
        RouletteSessionOptions = new HashSet<RouletteSessionOption>();
    }

    public Guid Id { get; private init; } = Guid.NewGuid();
    public Guid UserId { get; private set; }
    public Guid PatientId { get; private set; }
    public int RouletteOptionId { get; private set; }
    public virtual User User { get; }
    public virtual Patient Patient { get; }
    public virtual RouletteOption RouletteOption { get; }
    public ICollection<RouletteSessionOption> RouletteSessionOptions { get; }

    public RouletteSession SetRouletteSession(Guid userId, Guid patientId, int rouletteOptionId)
    {
        UserId = userId;
        PatientId = patientId;
        RouletteOptionId = rouletteOptionId;
        return this;
    }
}
