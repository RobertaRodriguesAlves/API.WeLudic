using WeLudic.Domain.Entities.Common;

namespace WeLudic.Domain.Entities;

public class RouletteOption : BaseAuditEntity
{
    public RouletteOption()
    {
        RouletteSessions = new HashSet<RouletteSession>();
        RouletteSessionOptions = new HashSet<RouletteSessionOption>();
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public Guid? UserId { get; private set; }
    public virtual User User { get; }
    public ICollection<RouletteSession> RouletteSessions { get; }
    public ICollection<RouletteSessionOption> RouletteSessionOptions { get; }

    public RouletteOption SetRouletteOptions(int id, string name)
    {
        Id = id;
        Name = name;
        return this;
    }

    public RouletteOption SetUserRouletteOptions(int id, string name, Guid userId)
    {
        Id = id;
        Name = name;
        UserId = userId;
        return this;
    }
}
