using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Entities.Common;

public abstract class BaseEntity : IEntity<Guid>
{
    public static readonly Guid AdminId = Guid.Parse("cf18e9f7-9694-49cb-8c14-dac7e76ba4e2");

    public Guid Id { get; } = Guid.NewGuid();
}
