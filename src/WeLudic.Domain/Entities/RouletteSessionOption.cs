namespace WeLudic.Domain.Entities;
public class RouletteSessionOption
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public Guid RouletteSessionId { get; private set; }
    public virtual RouletteSession RouletteSessions { get; }
    public int RouletteOptionId { get; private set; }
    public virtual RouletteOption RouletteOptions { get; }

    public RouletteSessionOption SetRouletteSessionOption(Guid rouletteSessionId, int rouletteOptionId)
    {
        RouletteSessionId = rouletteSessionId;
        RouletteOptionId = rouletteOptionId;
        return this;
    }
}
